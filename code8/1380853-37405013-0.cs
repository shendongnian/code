            List<ComputerGame> games = new List<ComputerGame>();
            games.Add(new ComputerGame("Age of Empires", 49.99));
            games.Add(new ComputerGame("Heroes and Generals", 30.00));
            games.Add(new ComputerGame("Team Fortress 2", 19.50));
            games.Add(new ComputerGame("Portal", 19.50));
            games.Add(new ComputerGame("Portal 2", 29.50));
            //looping the data
            foreach (ComputerGame item in games)
            {
                if (item != null)
                    Console.WriteLine("Name : " + item.title + " Price : " + item.price);
            }
            //get the sum of the price
            double total = games.Sum(p => p.price);
