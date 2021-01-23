    public class Trend
    {
        public string TrendName { get; set; }
        public string Description { get; set; }
    
        // This maintains the relationship between Trend and TrendyItem
        public List<TrendyItem> Items { get; set; }
    }
    
    public class Person
    {
        public string PersonName { get; set; }
        public int PersonId { get; set; }
        public int aptitude { get; set; }
    
        // Each person will specifiy a "TrendyItem"
        public TrendyItem Choice { get; set; }
    }
    
    public class TrendyItem
    {
        public string ItemName { get; set; }
        public string ItemId { get; set; }
    }
    
    public class TrendProfile
    {
        // Change this to to a key value pair. The key will be how you uniquely identify (input) the Trend in
        //2) Input: Trend; Output: List of trendy items belonging to that trend.
        // For example TrendName
        public Dictionary<string, Trend> FavoriteTrendsOfYear;
    
        // Change this to to a key value pair. The key will be how you uniquely identify (input) the Person in
        // 1) Input: Person; Output: List of Person's choice on trendy items.
        // For example PersonName
        public Dictionary<string, Person> ActivePeopleThisYear;
    
    
        public List<TrendyItem> TrendyItemsThisYear; 
    }
