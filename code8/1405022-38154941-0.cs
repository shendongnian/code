    class Account
    {
        public Account(List<string> groups)
        {
            Groups = groups.Select(s=>new Group(s)).ToList();
        }
        [JsonProperty("Groups")]
        public List<Group> Groups { get; set; }
    }
