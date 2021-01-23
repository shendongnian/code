            var prods = new List<Product>
            {
                new Product
                {
                    Name = "Im in stock",
                    Stock = InStock.InStock
                },
                new Product
                {
                    Name = "Im in stock too",
                    Stock = InStock.InStock
                },
                new Product
                {
                    Name = "Im not in stock",
                    Stock = InStock.NotInStock
                },
                new Product
                {
                    Name = "need to order me",
                    Stock = InStock.NotInStock
                },
            };
            var products = ProductInStockQuery(prods);
