    public class StockModel
    {
        //2016-02-29
        public DateTime Date { get; set; } // CsvHelper should be able to infer type
        //1437.530029
        public decimal Base { get; set; }
        //1445.839966
        public decimal Open { get; set; }
    }
    public static List<StockModel> SplitCsv(string csv)
    {
        var textReader = new StringReader(csv);
    
        var csvr = new CsvReader(textReader);
        
        var records = csvr.GetRecords<StockModel>().ToList();
        
        return records;
    }
