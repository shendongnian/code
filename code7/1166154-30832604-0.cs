     static void StartUp()
        {
            bool confirmChoice = false;
            Console.WriteLine("Hey, Enter your Character Name!");
            string name = Console.ReadLine();
            do
            {
            Console.WriteLine("Is " + name + " correct? (y) or would you like to change it (n)?");
            string input = Console.ReadLine();
            if (input == "n")
            {
                Console.WriteLine("Allright, enter your new Name then!");
                name = Console.ReadLine();
            }
            else
            {
                confirmChoice = true;
            }
            }while(confirmChoice==false);
        }
