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
         public IReadOnlyList<Product> Items 
         {
            get {return _items;
         }  
         public void AddItem(Product item)
         {
            _items.Add(item);
            item.QuantityChanged += ItemQuantityChanged;
            RecaclulateQuantity(); 
         }
         public void RemoveItem(Product item)
         {
            if (_items.Remove(item))
            {
               item.QuantityChanged -= ItemQuantityChanged;
               RecalculateQuantity();   
            }
 
         }
         public void ClearItems()
         {
             for(int i = _items.Count - 1; i >= 0; --i)
             {
                 var item = _items[i];
                 item.QuantityChanged -= ItemQuantityChanged;
                 _items.RemoveAt(i); 
             } 
             _quantity = 0;
         }
                    
         void RecalculateQuantity()
         {
             if (_updating)  return false; 
             _updating = true;
             try
             {
                int quantity;
                foreach(var item in _items)
                {
                   quantity += item.Quantity;
                }
                 
                this.Quantity = quantity;
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
