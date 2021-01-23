    static void Main()
        {
            string path = @"C:\Usernames.txt";
            if (File.Exists(path))
                Console.WriteLine("File already exists. Exiting the application...");
            else
            {
                List<string> list = new List<string>();
                string IsContinue = "Y";
                while (IsContinue.Equals("Y"))
                {
                    Console.WriteLine("Enter the username --");
                    string userName = Console.ReadLine();
                    if (!list.Contains(userName))
                    {
                        list.Add(userName);
                        File.AppendAllText(path, userName + Environment.NewLine);
                        Console.WriteLine("Success...! Continue (Y/N) ?", userName);
                        IsContinue = Console.ReadLine().ToUpper();
                    }
                    else
                        Console.WriteLine("{0} already exists. Choose a new Username again.\n", userName);
                }
            }
        }
