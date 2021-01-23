    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] inputs = {
                    "The.Voices.2014.720p.BDRip.x264.AC3-WiNTeaM.avi",
                    "13.Sins.2014.1080p.BluRay.DTS.x264.HDS.mkv",
                    "A.Million.Ways.to.Die.in.the.West.2014.1080p.WEB-DL.x264.AC3-EVO.mkv",
                    "Ant-Man.2015.1080p.BluRay.x264.SPARKS.mkv"
                };
                string pattern = @"(?'title'.*)\.(?'year'[^\.]+)\.(?'pixelsize'[^\.]+)\.(?'format'[^\.]+)\.(?'formatsize'[^\.]+)\.(?'filename'[^\.]+)\.(?'extension'[^\.]+)";
                foreach (string input in inputs)
                {
                    Match match = Regex.Match(input, pattern, RegexOptions.RightToLeft);
                    string extension = match.Groups["extension"].Value;
                    string fileName = match.Groups["filename"].Value;
                    string formatSize = match.Groups["formatsize"].Value;
                    string format = match.Groups["format"].Value;
                    string pixelSize = match.Groups["pixelSize"].Value;
                    string year = match.Groups["year"].Value;
                    string title = match.Groups["title"].Value;
                    title = title.Replace(".", " ");
                    Console.WriteLine("title = {0}, year = {1}, pixel size = {2}, Format = {3}, format size = {4}, filename = {5}.{6}",
                        title, year, pixelSize, format, formatSize,fileName, extension);
                }
                Console.ReadLine();
            }
        }
    }
    ​
