    public class DBData
    {
        public int CurrencyId { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal SellingRate { get; set; }
    }
    
    public class Program
    {
        private static void Main(string[] args)
        {
            var items = new List<DBData>();
    
            items.Add(new DBData { CurrencyId = 1, PublicationDate = DateTime.Parse("2014-08-19"), SellingRate = 34530m });
            items.Add(new DBData { CurrencyId = 2, PublicationDate = DateTime.Parse("2014-08-19"), SellingRate = 6117m });
            items.Add(new DBData { CurrencyId = 3, PublicationDate = DateTime.Parse("2014-08-19"), SellingRate = 13570m });
            items.Add(new DBData { CurrencyId = 1, PublicationDate = DateTime.Parse("2014-08-21"), SellingRate = 338263m });
    
            decimal result = items
                .Where(x => x.CurrencyId == 1)
                .OrderByDescending(x => x.PublicationDate)
                .Select(x => x.SellingRate)
                .DefaultIfEmpty()
                .First();
        }
    }
