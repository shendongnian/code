    public class SharePrices
    {
        public DateTime theDate { get; set; }
        public decimal sharePrice { get; set; }
    }
    SharePrices sp = new SharePrices() { theDate = DateTime.Now, sharePrice = 10 };
    
    var newList2 = new List<SharePrices>();
    newList2.Add(sp);
    newList2.ForEach(itemX => Console.WriteLine("Date: {0} Sharprice: {1}",sp.theDate, sp.sharePrice));
