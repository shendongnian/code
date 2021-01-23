    public class Product
    {
        public Product()
        {
            Prod = new tblProduct();
        }
        public tblProduct Prod { get; set; }
        public Nullable<int> Count { get; set; }
    }
