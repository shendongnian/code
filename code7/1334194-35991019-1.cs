    public class StockModel
    {
        //2016-02-29
        public DateTime Date { get; set; } // CsvHelper should be able to infer type
        //1437.530029
        public decimal Base { get; set; }
        //1445.839966
        public decimal Open { get; set; }
    }
