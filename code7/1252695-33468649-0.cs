    public class Inventory
    {
        public int ProductID { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public Inventory(int ID, string Description, decimal Price)
        {
            this.ProductID = ID;
            this.ProductDescription = Description;
            this.ProductPrice = Price;
        }
        public string DDLValue
        {
            get
            {
                return string.Format("{0}|{1}|{2}", ProductID, ProductDescription, ProductPrice);
            }
        }
        public string DDLText
        {
            get
            {
                return string.Format("{0} [{1}]", ProductDescription, ProductPrice.ToString("C"));
            }
        }
    }
