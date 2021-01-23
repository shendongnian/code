    public Item(string title, decimal price, string fName, string lName)
    {
        Title = title;            
        Price = price; 
        Item.Owner = new Vendor(fName, lName);
    }
