       private List<Product> _products = new List<Product>();
       _products.Add(new Product("Product_1"));
       _products.Add(new Product("Product_2"));
       
       //Before anybody gets antsy in their pantsy, I know the above is syntactically incorrect
       //It's for illustrative purposes only
  
        private void Generate() 
        {
            for (int i = 0; i < _products.Count(); i++) 
            {
                var cb = new CheckBox(); 
                cb.Name = _products[i].Name; //make it something generic like above, it'll help you check it
    
                cb.CheckedChanged += new EventHandler(cb_CheckedChanged);
            }
        }
        private void cb_CheckedChanged(object sender, EventArgs e)
        {
           var cBox = sender as CheckBox;
           if(cBox.Name == "Product_1")
               //handle business
        }
    
