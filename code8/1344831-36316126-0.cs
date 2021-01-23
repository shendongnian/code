    class Company
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("employees")]
        public List<Dictionary<string, Employee>> Employees { get; set; }
    }
    class Employee
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
