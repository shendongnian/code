    using System;
    class program
    {
        static void Main()
        {
            bool Flag = true;
            string action = "Null";
            decimal priceGain = 0M;
            Console.WriteLine("press 'q' or write \"quit\" to exit the application");
            while (Flag == true)
            {
                Console.WriteLine("What is the price Gain? ");
                string input = Console.ReadLine();
                if (decimal.TryParse(input, out priceGain))
                {
                    if (priceGain <= 2m)
                    {
                        action = "Sell";
                    }
                    else if (priceGain > 2m && priceGain <= 3m)
                    {
                        action = "Do Nothing";
                    }
                    else
                    {
                        action = "Buy";
                    }
                    Console.WriteLine(action);
                }
                else if (input.ToLower() == "q" || input.ToLower() == "quit")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid Input! please enter a number");
                }
            }
            Console.ReadKey();
        }
    }
