    public class BasketItem
    {
        public int BasketItemID { get; set; }
        public virtual int BasketID { get; set; }
        public int sellerID { get; set; }
        public string sellerSKU { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
