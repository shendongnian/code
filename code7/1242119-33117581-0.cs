            var random = new Random();
            while (true)
            {
                int RandomNumber = random.Next(1, 4);
                var userinput = Console.ReadLine();
                if (Enumerable.Range(1, 3).Contains(Convert.ToInt16(userinput)))
                    Console.WriteLine(userinput == RandomNumber.ToString() ? "Tied" : "Won");
                else
                    Console.WriteLine("Try Again!");
            }
