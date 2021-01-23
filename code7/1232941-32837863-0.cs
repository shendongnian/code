    public class VatRate
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ResourceUrl { get; set; }
    }
    
    public class Currency
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ResourceUrl { get; set; }
    }
    
    public class RevenueAccountDomestic
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ResourceUrl { get; set; }
    }
    
    public class RevenueAccountOutsideEU
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ResourceUrl { get; set; }
    }
    
    public class RevenueAccountEU
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ResourceUrl { get; set; }
    }
    
    public class Row
    {
        public int ItemId { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public string UnitOfMeasurement { get; set; }
        public string ItemType { get; set; }
        public VatRate VatRate { get; set; }
        public double Price { get; set; }
        public Currency Currency { get; set; }
        public RevenueAccountDomestic RevenueAccountDomestic { get; set; }
        public RevenueAccountOutsideEU RevenueAccountOutsideEU { get; set; }
        public RevenueAccountEU RevenueAccountEU { get; set; }
        public object StocksAccount { get; set; }
    }
    
    public class RootObject
    {
        public List<Row> Rows { get; set; }
        public int TotalRows { get; set; }
        public int CurrentPageNumber { get; set; }
        public int PageSize { get; set; }
    }
