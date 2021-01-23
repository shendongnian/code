    class Report
    {
        public Report()
        {
            this.Fields = new List<Field>();
        }
        [JsonProperty("fields", ObjectCreationHandling = ObjectCreationHandling.Replace)]
        public IList<Field> Fields { get; private set; }
    }
