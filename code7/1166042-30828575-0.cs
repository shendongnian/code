    public class Self
    {
        public string href { get; set; }
    }
    
    public class Teams
    {
        public string href { get; set; }
    }
    
    public class Fixtures
    {
        public string href { get; set; }
    }
    
    public class LeagueTable
    {
        public string href { get; set; }
    }
    
    public class Links
    {
        [JsonProperty("self")]
        public Self Self { get; set; }
        [JsonProperty("teams")]
        public Teams Teams { get; set; }
        [JsonProperty("fixtures")]
        public Fixtures Fixtures { get; set; }
        [JsonProperty("leagueTable")]
        public LeagueTable LeagueTable { get; set; }
    }
    
    public class RootObject
    {
        [JsonProperty("_links")]
        public Links Links { get; set; }
        [JsonProperty("caption")]
        public string Caption { get; set; }
        [JsonProperty("League")]
        public string League { get; set; }
        [JsonProperty("Year")]
        public string Year { get; set; }
        [JsonProperty("numberOfTeams")]
        public int NumberOfTeams { get; set; }
        [JsonProperty("NumberOfGames")]
        public int NumberOfGames { get; set; }
        [JsonProperty("LastUpdated")]
        public string LastUpdated { get; set; }
    }
