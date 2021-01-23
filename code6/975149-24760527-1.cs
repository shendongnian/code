    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {
                ""team_details"": {
                    ""0"": {
                        ""index"": 1,
                        ""team_id"": ""1.."",
                        ""team_name"": ""Research Team"",
                        ""team_url"": ""..."",
                        ""role"": ""Administrator""
                    },
                    ""1"": {
                        ""index"": 2,
                        ""team_id"": ""2.."",
                        ""team_name"": ""WB Team"",
                        ""team_url"": ""..."",
                        ""role"": ""User""
                    }
                }
            }";
            RootObject root = JsonConvert.DeserializeObject<RootObject>(json);
            foreach (Team team in root.Teams)
            {
                Console.WriteLine(team.TeamName);
            }
        }
    }
    public class RootObject
    {
        [JsonProperty("team_details")]
        [JsonConverter(typeof(TeamListConverter))]
        public List<Team> Teams { get; set; }
    }
    public class Team
    {
        [JsonProperty("index")]
        public int Index { get; set; }
        [JsonProperty("team_id")]
        public string TeamId { get; set; }
        [JsonProperty("team_name")]
        public string TeamName { get; set; }
        [JsonProperty("team_url")]
        public string TeamUrl { get; set; }
        [JsonProperty("role")]
        public string Role { get; set; }
    }
