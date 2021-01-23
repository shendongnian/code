    Product product = new Product();
 
    product.Name = "Apple";
    product.ExpiryDate = new DateTime(2008, 12, 28);
    product.Price = 3.99M;
    product.Sizes = new string[] { "Small", "Medium", "Large" };
 
    string output = JsonConvert.SerializeObject(product);
    //{
    //  "Name": "Apple",
    //  "ExpiryDate": "2008-12-28T00:00:00",
    //  "Price": 3.99,
    //  "Sizes": [
    //    "Small",
    //    "Medium",
    //    "Large"
    //  ]
    //}
    Product deserializedProduct = JsonConvert.DeserializeObject<Product>(output);
