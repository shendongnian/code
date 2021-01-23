            List<Player> list = new List<Player>();
            list.Add(new Player() { Name = "Player1", Points = 50 });
            list.Add(new Player() { Name = "Player2", Points = 60 });
            list.Add(new Player() { Name = "Player3", Points = 30 });
            list.Add(new Player() { Name = "Player4", Points = 80 });
            list.Add(new Player() { Name = "Player5", Points = 70 });
            list.Sort();
            foreach (var element in list)
            {
                Console.WriteLine(element.Name);
            }
