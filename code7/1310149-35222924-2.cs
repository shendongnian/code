    var product = new Product()
    {
        Name = "Product1",
        Id = 3,
        IsActive = true,
        Description = new Description
        {
            Content = "Content1",
            ShortContent = "ShortContent1"
        }
    };
    var result = ReadObject(product);
    var json = JsonConvert.SerializeObject(result);
