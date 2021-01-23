    using System;
    using System.Globalization;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication7
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] inputs = {
                    "01. Artist - Title.m4a",
                    "01: Artist - Title.aif",
                    "01 Artist - Title.mp3",
                    "Artist - Title.mp3",
                    "/Artist - Album/01. Title.aif",
                    "/Artist - Album/01: Title.m4a",
                    "/Artist - Album/01 Title.mp3",
                    "/Artist - Album/Title.mp3",
                    "/Artist/Album/01. Title.mp3",
                    "/Artist/Album/01: Title.m4a",
                    "/Artist/Album/01 Title.mp3",
                    "/Artist/Album/Title.aif"
                                 };
                string pattern =
                    @"^\d*[\.:]{0,1}\s*(?'artist'[^/][^-]+)\s+-\s+(?'title'[^\.]+)" +
                    "|" +
                    @"^/(?'artist'[^-]+)-\s+(?'album'[^/]+)/\d*[\.:]{0,1}\s*(?'title'[^\.]+)" +
                    "|" +
                    @"^/(?'artist'[^/]+)/(?'album'[^/]+)/\d*[\.:]{0,1}\s*(?'title'[^\.]+)";
                foreach (string input in inputs)
                {
                    Match match = Regex.Match(input, pattern);
                    Console.WriteLine("Artist : {0}, Album : {1}, Title : {2}",
                        match.Groups["artist"].Value.Trim(),
                        match.Groups["album"].Value.Trim(),
                        match.Groups["title"].Value.Trim()
                    );
                }
                Console.ReadLine();
            }
         }
    }
