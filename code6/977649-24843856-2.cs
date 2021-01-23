    public class Database
    {
        public List<Army> armies { get; set; }
    
        public Database()
        {
            armies = new List<Army>();
        }
        public Army AddNewArmy()
        {
            Army army = new Army();
            armies.add(army);
            return army;
        }
    }
