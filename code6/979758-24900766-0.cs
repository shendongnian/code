        internal static readonly Expression<Func<Product, ProductDto>>
            AsProductDto = product => new ProductDto
            {
                // single line call to setter
                Product = product
            };
        public class ProductDto
        {
            public ProductDto() { }
            public ProductDto(Product product)
            {
                // single line call to setter
                Product = product;
            }
            public ProductDto Product
            {
                set
                {
                    // no more repeated code 
                    Name = value.name;
                    // ...
                }
            }
        }
