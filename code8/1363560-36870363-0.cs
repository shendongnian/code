    class Program
    {
       public static void Main()
        {
            while(true)
            {
                    Console.WriteLine("Welcome");
                    Console.WriteLine("1 to go to Data Files ");
                    Console.WriteLine("type quit to exit");
                    string input = Console.ReadLine();
                    if (input == "1")
                    {
                        Data go = new Data();
                    }
                    else if (input == "quit")
                    {
                       return;
                    }
                    else
                    {
                      Console.WriteLine("invalid option");
                    }
            }
        }
    }
