        static void Main(string[] args)
        {
            var latestModifiedFile = GetLatestModifiedFile(@"C:\");
            Console.WriteLine(latestModifiedFile);
        }
