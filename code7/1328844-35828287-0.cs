     static void Main(string[] args)
            {
                Player player = new Player
                {
                    PlayerTeam = new Team { Name ="ABC", TeamId= 20 }, PlayerId = 3
                };
    
    
                string json = JsonConvert.SerializeObject(player, Formatting.Indented);
    
                Console.WriteLine(json);
    
                Player player_Des = JsonConvert.DeserializeObject<Player>(json);
    
                Console.WriteLine(player_Des.PlayerTeam.Name);
    
                Console.ReadLine();
            }
