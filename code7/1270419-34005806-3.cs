        private void Match()
    {
        var players = new Player[3].ToList();
        foreach (var found in players.ToList().Select(player => players.FirstOrDefault(p => p.Number == player.Number)))
        {
            if (found != null)
            {
                Console.WriteLine("Same");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Not");
                Console.ReadLine();
            }
        }
    }
