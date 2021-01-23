    public Item(string title, decimal price, string fName, string lName)
        {
            Title = title;            
            Price = price;
            Owner = new Vendor(fName, lName);
