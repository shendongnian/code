    public class Identification
    {
        public string lineItem_latestDate { get; set; }
        public string lineItem_destination { get; set; }
        public string lineItem_quantity { get; set; }
    }
    public class RootObject
    {
        public Identification identification { get; set; }
    }
