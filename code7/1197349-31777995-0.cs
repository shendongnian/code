    [StepArgumentTransformation]
    public IEnumerable<Product> TransformProductData(Table table)
    {
        var mapData = new Dictionary<string,string>();
        mapData.Add("Name","N");
        mapData.Add("Category", "C");
        var prodProcessors = typeof(Product).GetProperties()
          .Where(prop => mapData.ContainsKey(prop.Name))
          .Select(prop => new { Property = prop, Value = mapData[prop.Name]})
          .ToList();
        foreach(var product in table.CreateSet<Product>)
        {
          prodProcessors.ForEach(x => x.Property.SetValue(product, x.Value));
        }
    }
