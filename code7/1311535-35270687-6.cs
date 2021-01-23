    static void Main(string[] args)
    {
        demo obj = new demo();
        string uname, pass;
        Console.ForegroundColor = ConsoleColor.Green;
        int maxTries;
        int tries = maxTries = 5;
        do
        {
            if (tries != maxTries)//second and more
            {
                Console.Clear();
                Console.WriteLine("Invalid");
                Console.Write("\n\t" + tries + " Tries left");
                Console.WriteLine("\n\n\n\tTry again? (y/n)");
                string input;
                do
                {
                    input = Console.ReadLine();
                } while (input != "y" && input != "n");
                if (input == "n")
                {
                    return; // exit the program
                }
            }
            Console.Clear();
            Console.WriteLine("Enter username");
            uname = Console.ReadLine();
            Console.WriteLine("Enter Password");
            pass = Console.ReadLine();
            obj.setName(uname);
            obj.setPass(pass);
            tries--;
        } while (obj.getName() != "niit" || obj.getPass() != "1234");
        Console.WriteLine("Wellcome");
    }
