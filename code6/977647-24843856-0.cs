    public class Database
    {
        public List<Army> Armies { get; set; }
    
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
