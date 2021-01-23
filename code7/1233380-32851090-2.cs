    public class Person
    {
        public string FirstName { get; set;}
        public string LastName { get; set;}
        [JsonIgnore]
        public string Json { get; set; }
        
        [JsonProperty("Json")]
        private JRaw MyJson
        {
            get { return new JRaw(this.Json); }
            set { this.Json = value.ToString(); }
        }        
    }
