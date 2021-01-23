    static void Main(string[] args)
        {
            //initialise bool for loop
            bool flag = false;
            
            //While loop to loop Menu
            while (!flag)
            {
                Console.WriteLine("Menu Selection");
                Console.WriteLine("Press 'a' for apple");
                Console.WriteLine("Press 'b' for bobby");
                Console.WriteLine("Type 'exit' to exit");
                //Read userinput
                //Store inside string variable
                string menuOption = Console.ReadLine();
                switch (menuOption)
                {
                    case "a":
                        //Clears console for improved readability
                        Console.Clear();
                        //"\n" Creates empty line after statement
                        Console.WriteLine("apple has been selected\n");
                        //Break out of switch
                        break;
                    case "b":
                        Console.Clear();
                        Console.WriteLine("bobby has been selected\n");
                        break;
                    case "exit":
                        Console.Clear();
                        Console.WriteLine("You will now exit the console");
                        //bool set to false to exit out of loop
                        flag = true;
                        break;
                        //Catch incorrect characters with default
                    default:
                        Console.Clear();
                        //Error message
                        Console.WriteLine("You have not selected an option\nPlease try again\n\n");
                        break;
                } 
            } 
            Console.ReadLine();
