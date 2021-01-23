    class Program
    {
        private static readonly string PATH_TO_FILES = @"d:\temp";
        static void Main(string[] args)
        {
            using (var watcher = new FileSystemWatcher(PATH_TO_FILES, "*.pdf"))
            {
                watcher.Changed += Watcher_Changed;
                WriteHelp();
                while (true)
                {
                    Console.Write("Cmd ->");
                    string k = Console.ReadLine();
                    switch (k)
                    {
                        case "help":
                            WriteHelp();
                            break;
                        case "runAll":
                            string[] allFiles = System.IO.Directory.GetFiles(PATH_TO_FILES);
                            foreach (string curr in allFiles)
                            {
                                parseTheFile(curr);
                            }
                            break;
                        case "quit":
                            return;
                        default:
                            Console.WriteLine("Huh?  Unknown command!");
                            break;
                    }
                }
            }
        }
        private static void WriteHelp()
        {
            Console.WriteLine("HELP:");
            Console.WriteLine(@"");
            Console.WriteLine("RENAMES FILES THAT ARE PLACED INTO THE WORKING FOLDER.");
            Console.WriteLine("*************_Commands:_************");
            Console.WriteLine("'runAll' = will run the program on all files curently existing in the folder.  Note that if a file has already been renamed the program SHOULD attempt the rename, find the file has already been renamed, and move to the next file.");
            Console.WriteLine("'quit' = exits program");
            Console.WriteLine("'help' = shows this spiffy information.");
            Console.WriteLine("[end]");
            Console.WriteLine("");
        }
        private static void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            try
            {
                Console.WriteLine("New file found: " + e.Name);
                parseTheFile(e.FullPath);
            }
            catch(Exception exception)
            {
                Console.WriteLine("Exception: " + exception.Message);
            }
        }
        private static void parseTheFile(string fullPath)
        {
            throw new NotImplementedException();
        }
    }
