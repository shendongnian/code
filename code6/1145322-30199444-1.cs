    public class LeagueTeams
    {
        public List<IDictionary<string, string>> _links { get; set; }
        public string count { get; set; }
        public List<LeagueTeam> teams { get; set; }
    }
    return JsonConvert.DeserializeObject<LeagueTeams>(content);
