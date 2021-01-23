    static void Main()
    {
        string userChoice,number;
        int checkInt;
        Console.WriteLine("Do you want check even/odd number?y/n");
        userChoice = Console.ReadLine();
        if (userChoice.ToLower().Equals("y"))
        {
            do
            {
                Console.WriteLine("Please enter your number");
                number = Console.ReadLine();
                if (int.TryParse(number, out checkInt))
                {
                    if ((checkInt % 2) == 0)
                    {
                        Console.WriteLine("Your entered number {0} is even", checkInt);
                    }
                    else
                    {
                        Console.WriteLine("Your entered number {0} is odd", checkInt);
                    }
                }
                else
                {
                    Console.WriteLine("Plesae enter integer value");
                }
                Console.WriteLine("Do you want check even/odd number?y/n");
                userChoice = Console.ReadLine();
            } while (userChoice.ToLower().Equals("y"));
        }
    }
