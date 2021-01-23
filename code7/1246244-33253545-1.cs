    class DirectoryHelper
    {
        public static void Test()
        {
            DirectoryHelper.EnumerateSubDirectories(@"c:\windows\system32");
        }
        public static List<string> EnumerateSubDirectories(string path)
        {
            // Depending on your use case, it might be 
            // unecessary to save these in memory 
            List<string> allSubdirs = new List<string>();
            EnumerateSubDirectories(path,
                filePath => Console.WriteLine("Visited file: " + filePath),
                dirPath => allSubdirs.Add(dirPath),
                noAccessPath => Console.WriteLine("No access: " + noAccessPath)
            );
            return allSubdirs;
        }
        private static void EnumerateSubDirectories(string root, Action<string> fileAction, Action<string> subdirAction, Action<string> noAccessAction)
        {
            foreach (string file in Directory.GetFiles(root))
            {
                fileAction(file);
            }
            foreach (string dir in Directory.GetDirectories(root))
            {
                try
                {
                    subdirAction(dir);
                    EnumerateSubDirectories(dir, fileAction, subdirAction, noAccessAction);
                }
                catch (UnauthorizedAccessException)
                {
                    noAccessAction(dir);
                }
            }
        }
    }
