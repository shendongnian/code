    using System;
    namespace Dicey
    {
        class Program
        {
            static void Main(string[] args)
            {
                int numberOfDice;
                // check for and retrieve the number of dice the user wants.
                if (args.Length != 1 || !int.TryParse(args[0], out numberOfDice))
                {
                    Console.WriteLine("Please provide the number of dice.");
                    return; // exit because arg not provided
                }
                // Must have at least one and set some arbitrary upper limit
                if (numberOfDice < 1 || numberOfDice > 50)
                {
                    Console.WriteLine("Please provide a number of dice between 1 and 50");
                    return; // exist because not in valid range
                }
                var dice = new int[numberOfDice]; // create array of die (ints)
                var rand = new Random();
                var match = false; // start with false (match not found yet)
                while (!match) // loop until match becomes true
                {
                    var message = string.Empty;
                    match = true; // assume match until something doesn't match
                    for (var i = 0; i < numberOfDice; i++)
                    {
                        // initialize dice at index i with the random number
                        dice[i] = rand.Next(1, 7);
                        // build the message line to write to the console
                        message += dice[i]; // first add the die's number
                        if (i < numberOfDice - 1)
                            message += "\t"; // if not at the end, add a tab
                        // check if the previous die (except for the first of course) has a different number
                        if (i > 0 && dice[i - 1] != dice[i]) 
                            match = false; // uh oh, not all match. we have to keep going
                    }
                    // print out the message
                    Console.ForegroundColor = match ? ConsoleColor.Yellow : ConsoleColor.White;
                    Console.WriteLine(message);
                }
                Console.ReadLine();
            }
        }
    }
