    class Product
            {
                public int ProductId { get; set; }
                public int ProductVariantId { get; set; }
            }
    
            static void GetMaxProduct(IList<Product> list,int variant)
            {
                var query = from l in list
                            group l by l.ProductId into g
                            select g.FirstOrDefault(x => x.ProductVariantId == variant) ?? g.OrderBy(x => x.ProductVariantId).Last();
                foreach (Product p in query)
                {
                    Console.WriteLine("ProductId:" + p.ProductId + " ProductVariantId:" + p.ProductVariantId);
                }
            }
    
            static void Main(string[] args)
            {
                List<Product> list = new List<Product>()
                {
                    new Product{ ProductId=1, ProductVariantId=1},
                    new Product{ ProductId=1, ProductVariantId=2},
                    new Product{ ProductId=2, ProductVariantId=1},
                    new Product{ ProductId=2, ProductVariantId=2},
                    new Product{ ProductId=2, ProductVariantId=3},
                };
    
                GetMaxProduct(list, 3);
                GetMaxProduct(list, 4);
                GetMaxProduct(list, 1);
            }
