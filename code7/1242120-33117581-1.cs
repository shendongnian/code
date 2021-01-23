            var random = new Random();
            while (true)
            {
                int RandomNumber = random.Next(1, 4);
                var userinput = Console.ReadLine();
                if (Enumerable.Range(1, 3).Contains(Convert.ToInt16(userinput)))
                    if (userinput == RandomNumber.ToString())
                        Console.WriteLine("Tied");
                    else
                        Console.WriteLine("Check and see who won!");
                else
                    Console.WriteLine("Try Again!");
            }
