    var product = new ProductService.Models.Product()
            {
                Name = "My Car",
                Category = "Auto",
                Price = 4.85M
            };
            var supplier = new ProductService.Models.Supplier()
            {
                Name = "My Name"
            };
            //Add product to supplier
            supplier.Products.Add(product);
            WebClient client = new WebClient();
            client.BaseAddress = "http://example.com/OData";
            client.Headers.Add("Content-Type", "application/json");
            //Serialize supplier object
            var serializer = new JavaScriptSerializer();
            var serializedResult = serializer.Serialize(supplier);
            //Call the service
            var result = client.UploadString("http://example.com/OData/Suppliers", serializedResult.ToString());
            
