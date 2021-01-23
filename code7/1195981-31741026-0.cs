    //Don't embed database logic directly in the aspx files
    public class GamesProvider
    {        
        //Put the ConnectionString in you configuration file
        private string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["GameDB"].ConnectionString; }
        }
        
        public IEnumerable<Game> LoadGames(string x, string y)
        {
            var games = new List<Game>();
            const string queryString = "select name, Abbr from dbo.Games where x = @x and y = @y";
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(queryString, connection))
            {
                command.Parameters.AddWithValue("@x", x);
                command.Parameters.AddWithValue("@y", y);
                using (var dateReader = command.ExecuteReader())
                {
                    while (dateReader.Read())
                    {
                        var game = new Game
                        {
                            Name = dateReader["name"].ToString(),
                            Abbr = dateReader["Abbr"].ToString(),
                        };
                        games.Add(game);
                    }
                }
            }
            return games;
        }
    }
    //Use types
    public class Game
    {
        public string Name { get; set; }
        public string Abbr { get; set; }
    }
