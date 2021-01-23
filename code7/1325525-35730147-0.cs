    Console.WriteLine("Good Morning, " + name);
    Console.ReadKey();
    static void Main(string[] args)
        {
          
            int i = 0; //this should really be bool, 
            //because all you're doing is using 0 for repeat and 1 for stop. 
            while (i == 0)
            {
                Console.Write("What is your name?\n>>> ");
                string name = Console.ReadLine();
                if ((name == "Alice") || (name == "Bob"))
                {
                    i = 1;
                    Console.Clear();
                    Console.WriteLine("Good Morning, " + name); //"name" is unassigned
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("You're not Alice or Bob.");
                    Console.ReadKey();
                    i = 0;
                    Console.Clear();
                }
            }
        }
    }
