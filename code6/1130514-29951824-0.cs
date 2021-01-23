    var createData = new
                {
                    name = "Test Product,
                    type = "physical",
                    description = "test",
                    price = "25.99",
                    availability = "available",
                    is_visible = true,
                    weight = "3"    
                };
    
     string url = String.Format("products");
                var response = HttpClient.PostAsJsonAsync(url, createData);
                Console.WriteLine(response.Result);
                Console.ReadLine();
