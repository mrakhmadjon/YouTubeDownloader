using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VideoLibrary;

namespace YouTubeDownloader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string video_url = "https://www.youtube.com/watch?v=RWYrafpP53A";

            Console.WriteLine("Videoni Kachestvasini kiriting : ");
            int video_size =int.Parse(Console.ReadLine());

            if (video_size != 720 || video_size != 360 || video_size != 1080)
                video_size = 720;

            YouTube yt = YouTube.Default;

            List<YouTubeVideo> videos = yt.GetAllVideos(video_url).ToList();

            YouTubeVideo video = videos.FirstOrDefault(p => p.Resolution == 360 && p.FileExtension == ".mp4");

            Console.WriteLine("Boshlandi...");

            byte[] file = video.GetBytes();

            File.WriteAllBytes(@"D:\xira.mp4", file);

            Console.WriteLine("Downloaded ");
        }
    }
}
