    using System;
    namespace Dicey
    {
        class Program
        {
            static void Main(string[] args)
            {
                int numberOfDice;
                if (args.Length != 1 || !int.TryParse(args[0], out numberOfDice))
                {
                    Console.WriteLine("Please provide the number of dice.");
                    return;
                }
                if (numberOfDice < 1 || numberOfDice > 50)
                {
                    Console.WriteLine("Please provide a number of dice between 1 and 50");
                    return;
                }
                var dice = new int[numberOfDice];
                var rand = new Random();
                var match = false;
                while (!match)
                {
                    var message = string.Empty;
                    match = true;
                    for (var i = 0; i < numberOfDice; i++)
                    {
                        dice[i] = rand.Next(1, 7);
                        message += dice[i];
                        if (i < numberOfDice - 1)
                            message += "\t";
                        if (i > 0 && dice[i - 1] != dice[i]) 
                            match = false;
                    }
                    Console.ForegroundColor = match ? ConsoleColor.Yellow : ConsoleColor.White;
                    Console.WriteLine(message);
                }
                Console.ReadLine();
            }
        }
    }
