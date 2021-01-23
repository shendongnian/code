    static void Main(string[] args)
    {
        XDocument XDoc = XDocument.Load("inventory.xml"); // Loading XML file
        var result = from q in XDoc.Descendants("product")
            select new Product
                {
                    RecordNumber = Convert.ToInt32(q.Element("recordNumber").Value),
                    Name = q.Element("name").Value,
                    Stock = Convert.ToInt32(q.Element("stock").Value),
                    Price = Convert.ToInt32(q.Element("price").Value)
                 };
        var cart = new Cart();
    
        foreach(var prod in result)
        {
            cart.AddProduct(prod);
        }
        // Now the cart object has all product items - do something with it?
    }
