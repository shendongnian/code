    private void LoadData()
    {
        // Load the document
        _document = XDocument.Load("Product.xml");
        // Get the root's children, here is the products
        IEnumerable<XElement> products = _document.Root.Elements();
        // Get product name
        var productNames = new List<string>();
        foreach (var element in products)
        {
            productNames.Add(element.Attribute("Name").Value);
        }
        // Assign to the source
        ddlProduct.DataSource = productNames;
    }
