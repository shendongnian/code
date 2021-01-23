    class Product
    {
        public int Quantity 
        { 
            get { return _quantity}; 
            set 
            { 
                if (_quantity != value) 
                {
                   _quantity = value; 
                   OnQuantityChanged();
                }
            }
        }
        protected virtual void OnQuantityChanged()
        {
            var handler = QuantityChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }   
        int _quantity; 
        public event EventHandler QuantityChanged;   
    }
    class BundleProduct: Product
    {
         public class BundleItem 
         {
            public BundleItem(Product product, int requiredQuantity)
            {
               this.Product = product;
               this.RequiredQuantity = requiredQuantity;
            }
            public int Quanity
            {
                 get {return Product.Quantity / RequiredQuantity; }
            }
             
            public readonly Product Product;
            public readonly int RequiredQuantity;  
         }
        
         public IReadOnlyList<BundleItem> Items 
         {
            get {return _items;
         }  
         public void AddItem(Product product, int requiredQuantity)
         {
            var item = new BundleItem(product, requiredQuantity);
            _items.Add(item);
            product.QuantityChanged += ItemQuantityChanged;
            RecaclulateQuantity(); 
         }
                    
         void RecalculateQuantity()
         {
             if (_updating)  return false; 
             _updating = true;
             try
             {
                // The quantity of a bundle is derived from 
                // availability of items it contains   
                int available = 0;
                if (_items.Count != 0)
                {
                    available = _items[0].Quantity;  
                    for(int i = 1; i < _items.Count; ++i)
                    {
                       available = Math.Min(available, _items[i].Quanity);
                    }  
                }
                this.Quantity = available;
             }
             finally
             {
                 _updating = false;
             }
         }        
         void ItemQuantityChanged(object sender, EventArgs e)
         {
             RecalculateQuantity();
         }
         bool _updating; 
         List<Product> _items;
    }
