    public class yourClass
    {
        public string ID { get; set; }
        public string Description { get; set; }
        public string StockItem { get; set; }
        public string MinimumStock { get; set; }
    }
    List<yourClass> result = new List<yourClass>();
    db.Extras.ToList().ForEach(c => result.Add(new yourClass { ID="" , Description="" , MinimumStock="" , StockItem="" }));
