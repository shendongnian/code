    HttpClient client = new HttpClient();
    Uri baseAddress = new Uri("http://localhost:2939/");
    client.BaseAddress = baseAddress;
 
    ArrayList paramList = new ArrayList();
    Product product = new Product { ProductId = 1, Name = "Book", Price = 500, Category = "Soap" };
    Supplier supplier = new Supplier { SupplierId = 1, Name = "AK Singh",     Address = "Delhi" };
    paramList.Add(product);
    paramList.Add(supplier);
 
    HttpResponseMessage response = client.PostAsJsonAsync("api/product/SupplierAndProduct", paramList).Result;
        
     
