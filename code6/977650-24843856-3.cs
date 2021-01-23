    public class Database
    {
        public List<Army> armies { get; set; }
    
        public Database()
        {
            armies = new List<Army>();
            armies.Add(new Army());
        }
        [JsonConstructor]
        private Database(string notUsed)
        {
        }
    }
