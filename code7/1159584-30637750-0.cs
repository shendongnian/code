    public class ReactorParameters
    {
        public TimeSpan Time { get; set; }
    
        public double Temperature { get; set; }
    
        public double Oil { get; set; }
    
        public double Air { get; set; }
    }
    
    public class ProductInformation
    {
        public TimeSpan Time_From { get; set; }
    
        public TimeSpan Time_To { get; set; }
    
        public string Product { get; set; }
    }
    
    public class ReactorView
    {
        public ReactorParameters Parameters { get; set; }
        public ProductInformation Product { get; set; }
    }
    
    /// <summary>
    /// entry point
    /// </summary>
    public void Test()
    {
        Random rnd = new Random(1000);
    
        // random parameters
        List<ReactorParameters> parameters = (from i in Enumerable.Range(0, 24)
                                              select new ReactorParameters
                                              {
                                                  Time = TimeSpan.FromHours(i),
                                                  Temperature = rnd.NextDouble() * 50.0,
                                                  Oil = rnd.NextDouble() * 20.0,
                                                  Air = rnd.NextDouble() * 30.0,
                                              }).ToList();
    
        // product information
        List<ProductInformation> products = (from i in Enumerable.Range(0, 4)
                                             select new ProductInformation
                                             {
                                                 Time_From = TimeSpan.FromHours(i * 6),
                                                 Time_To = TimeSpan.FromHours(i * 6 + 6),
                                                 Product = "Product " + (char)('A' + i),
                                             }).ToList();
    
    
        // combine
        var result = parameters.SelectMany(param => from product in products
                                                    where param.Time >= product.Time_From && param.Time <= product.Time_To
                                                    select new ReactorView
                                                    {
                                                        Parameters = param,
                                                        Product = product
                                                    });
    
        // print result
        foreach (var item in result)
        {
            Console.WriteLine("{0,-5} {1,-8:0.00} {2,-8:0.00} {3,-8:0.00} {4,-10}",
                item.Parameters.Time, item.Parameters.Temperature, item.Parameters.Air, item.Parameters.Oil, item.Product.Product);
        }
    }
