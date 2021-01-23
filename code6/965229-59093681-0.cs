            Console.WriteLine("1. Add account.");
            Console.WriteLine("Enter choice: ");
            int choice = 0;
            while (!Int32.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Wrong input! Enter choice number again:");
            }
