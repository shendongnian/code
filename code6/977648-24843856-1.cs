    public class Database
    {
        public List<Army> Armies { get; set; }
    
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
