    public class PriceList
    {
        public string itemDescription { get; set; }
        public DateTime listDate { get; set; }
        public decimal listPrice { get; set; }
        public int theVolume { get; set; }
        public override string ToString()
        {
            return String.Format("Item: {0}; Date: {1}; Price: {2}; Volume {3};", itemDescription, listDate, listPrice, theVolume);
        }
    }
