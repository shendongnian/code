       static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main(string[] args)
            {
                if (args.Length == 1) //make sure an argument is passed
                {
                    FileInfo file = new FileInfo(args[0]);                
                    if (file.Exists) //make sure it's actually a file
                    {
                        File.Copy(file.FullName, "./workspace.tmp"); //copys the associated file to the program folder and renames it. 
                    // This is importants since the name of the file can be anything *.wsda
                    }
                }
                   
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }
