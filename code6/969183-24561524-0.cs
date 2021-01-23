    public class ItemStatus
    {
        private bool inStock;
    
        public Item(bool inStock)
        {
            this.inStock = inStock;
        }
    
        public string Value 
        { 
            get { return inStock ? "In Stock" : "Sold Out"; }
        }
    }
