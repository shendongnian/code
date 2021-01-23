    List<String> products = new List<String>();
    
    public void addToTextBox(string product)
    {
        products.Add(product);
        while(products.Count>20)
        {
             products.RemoveAt(0);
        }
        
        /* Refresh textbox */
           
        textBox.Text="";
        
        foreach(var p in products)
        {
            textBox.Append(p);
        }
    }
