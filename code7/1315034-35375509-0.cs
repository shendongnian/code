    static void Exercise2()
        {
            
            string entry;
            Console.Write("Enter an integer or 'q' to quit: ");
            entry = Console.ReadLine();
            while (entry.ToLower() != "q")
            {
                int number;
                if (int.TryParse(entry, out number))
                {
                    if (number >= 1 && number <= 10)
                    {
                        Console.WriteLine("Coool");
                    }
                    else
                    {
                        Console.WriteLine("Your number must be between 1 and 10");
                    }
                }
                Console.Write("Enter an integer or 'q' to quit: ");
                entry = Console.ReadLine();
            }
            
        }
