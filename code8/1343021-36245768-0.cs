        public static IList<Type> GetProducts()
        {
            var products = new List<Products>()
            {
                new Products { ID="1",Name="Soap",Price="200"},
                new Products { ID="2",Name="Trouser",Price="300"},
                new Products { ID="3",Name="Shirt",Price="400"}
            }.ToList();
            return products.Select(x => x.GetType()).ToList();            
        }
