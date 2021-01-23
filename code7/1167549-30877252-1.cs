    Product[] products = { new Product { Name = "apple", Code = 9 }, 
                           new Product { Name = "orange", Code = 4 }, 
                           new Product { Name = "apple", Code = 9 }, 
                           new Product { Name = "lemon", Code = 12 } };
    
    //Exclude duplicates.
    
    IEnumerable<Product> noduplicates =
        products.Distinct();
