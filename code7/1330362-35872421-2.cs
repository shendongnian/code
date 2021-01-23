        static void Main(string[] args)
        {
            var latestModifiedFile = GetLatestModifiedFile(@"Path here");
            Console.WriteLine(latestModifiedFile);
            System.Diagnostics.Process.Start(latestModifiedFile)
        }
        static string GetLatestModifiedFile(string directory)
        {
            var files = Directory.GetFiles(directory);
            return files.OrderBy(f => File.GetLastWriteTime(f)).LastOrDefault();
        }
