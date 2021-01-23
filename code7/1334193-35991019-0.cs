    public class StockModel
    {
        public DateTime Date { get; set; } // CsvHelper should be able to infer type
        public string Base { get; set; }
        public string Open { get; set; }
    }
