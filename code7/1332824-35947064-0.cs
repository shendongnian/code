    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (File.Exists(@"c:\Usernames.txt"))
                {
                    Console.WriteLine("File already exists");
                    return;
                }
                else
                {
                    string sContinue = "yes";
                    HashSet<string> sUserNames = new HashSet<string>();
                    while (sContinue.Equals("yes"))
                    {
                        Console.WriteLine("Enter username:");
                        string sUserName = Console.ReadLine();
                        if (!sUserNames.Contains(sUserName))
                        {
                            sUserNames.Add(sUserName);
                            using (StreamWriter oWriter = new StreamWriter(@"c:\Usernames.txt", true))
                                oWriter.WriteLine(sUserName);
                            Console.WriteLine("Username {0} was added.Enter yes to continue or no to exit", sUserName);
                        }
                        else
                            Console.WriteLine("Username {0} exists.Enter yes to add new username or no to exit", sUserName);
                        sContinue = Console.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Done");
            Console.Read();
        }
    }
