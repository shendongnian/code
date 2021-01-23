     static void Main(string[] args)
        {
            string sourceFolder = @"C:\dom";
            string searchWord = "&#x9";            
            string regexPattern = @"@([A-Za-z0-9\-_]+).\&#x9";
            List<string> allFiles = new List<string>();
            AddFileNamesToList(sourceFolder, allFiles);
            foreach (string fileName in allFiles)
            {
                string contents = File.ReadAllText(fileName);
                if (showMatch(contents, regexPattern))
                {
                    if (contents.Contains(searchWord))
                    {
                        Console.WriteLine(fileName);
                    }
                }
            }
            Console.WriteLine(" ");
            System.Console.ReadKey();
        }
        private static bool showMatch(string text, string expr)
        {
            Console.WriteLine("The Expression: " + expr);
            MatchCollection mc = Regex.Matches(text, expr);
            foreach (Match m in mc)
            {
                Console.WriteLine(m);
            }
            return mc.Count > 0;
        }
        public static void AddFileNamesToList(string sourceDir, List<string> allFiles)
        {
            string[] fileEntries = Directory.GetFiles(sourceDir);
            foreach (string fileName in fileEntries)
            {
                allFiles.Add(fileName);
            }
            //Recursion    
            string[] subdirectoryEntries = Directory.GetDirectories(sourceDir);
            foreach (string item in subdirectoryEntries)
            {
                // Avoid "reparse points"
                if ((File.GetAttributes(item) & FileAttributes.ReparsePoint) != FileAttributes.ReparsePoint)
                {
                    AddFileNamesToList(item, allFiles);
                }
            }
        }
