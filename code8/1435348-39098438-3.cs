    public class ProductionCompany
    {
        public string name { get; set; }
        public int id { get; set; }
    }
    
    public class Item
    {
        public double popularity { get; set; }
        public List<ProductionCompany> production_companies { get; set; }
    }
