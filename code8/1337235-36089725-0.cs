    public static void NullChecker() {
        Console.Write("Age: ");
        String input = Console.ReadLine();
        
        int age = 0;
        if (Int32.TryParse(input, out age))
        {
            if (age >= 16)
            {
                Console.WriteLine("Welcome!");
            }
            else
            {
                Console.WriteLine("You are too young!");
                Console.WriteLine("See you soon!");
            }
        }
        else
        {
            Console.WriteLine("You cant leave it blank!");
        }
    }
