            Regex myRegex = new Regex("^(?:(?:0)|(?:0.[0-9]{1,4}))$");
            Console.WriteLine("Regex: " + myRegex + "\n\nEnter test input.");
            while (true)
            {
                string input = Console.ReadLine();
                if (myRegex.IsMatch(input))
                {
                    Console.WriteLine(input + " is a match.");
                }
                else
                {
                    Console.WriteLine(input + " isn't a match.");
                }
            }
