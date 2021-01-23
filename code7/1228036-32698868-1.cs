    private void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        // New value
        string productName = ddlProduct.Text;
        // Ignore empty value, or your XPath would be wrong
        if (String.IsNullOrEmpty(productName))
        {
            return;
        }
        // Build the XPath
        string xPath = string.Format("//Product[@Name='{0}']", productName);
        // Select product with that name
        XElement product = _document.XPathSelectElement(xPath);
        // Select the CategoryType
        IEnumerable<XElement> categories = product.Descendants("CatagoryType");
        // Get the name
        var categoryNames = new List<string>();
        foreach (var category in categories)
        {
            categoryNames.Add(category.Value);
        }
        // Assign to source
        ddlCategory.DataSource = categoryNames;
    }
