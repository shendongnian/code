            string input = "";
            int Sum = 0, newNumber;
            while (input != "00")
            {
                Console.Write("Enter number(press 00 to print the sum): ");
                input = Console.ReadLine();
                if (!Int32.TryParse(input, out newNumber))
                {
                    Console.WriteLine("Input is not a valid number; 0 is taken as default value");
                }
                Sum += newNumber;
            }
            Console.WriteLine(" Sum of entered numbers {0}",Sum);
            Console.ReadKey();
