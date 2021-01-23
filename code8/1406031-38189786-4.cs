    Dictionary<string, Product> file1 = new Dictionary<string, Product>();
    Dictionary<string, Product> file2 = new Dictionary<string, Product>();
    
    //Add ProductCode in key
    
    var product = new Product();
    product.Code = "EAN1202";
    product.Manufacturer = "Company";
    product.Name = "Test";
    product.Price = 12.05;
    
    file1.Add(product.Code, product);
    
    //One thread
    foreach (var item in file1)
    {
       if (file2.ContainsKey(item.Key))
       {
          // Do Some Stuff
       }
    }
    
    //Multi thread
    Parallel.ForEach(file1, item =>
    {
       if (file2.ContainsKey(item.Key))
       {
          // Do Some Stuff
       }
    });
