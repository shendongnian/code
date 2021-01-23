    public class Players : List<Player>
    {
    }
    public class Player
    {
        public Player()
        {
            PlayerTeam = new Team();
        }
        public int PlayerId { get; set; }
        public Team PlayerTeam { get; set; }
    }
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
    }
...
    var json = "[{ \"PlayerId\": 3, \"PlayerTeam\": { \"TeamId\": 20, \"Name\": \"ABC\" } },{ \"PlayerId\": 4, \"PlayerTeam\": { \"TeamId\": 21, \"Name\": \"ABCD\" } }]";
    var players = JsonConvert.DeserializeObject<Players>(json);
    foreach (var player in players)
    {
        Console.WriteLine($"{player.PlayerId}, {player.PlayerTeam.TeamId} - {player.PlayerTeam.Name}");
    }
