        public class ProductRepository
        {
            private readonly IDatabaseConnectionFactory connectionFactory;
    
            public ProductRepository(IDatabaseConnectionFactory connectionFactory)
            {
                this.connectionFactory = connectionFactory;
            }
    
            public Task<IEnumerable<Product>> GetAll()
            {
                return this.connectionFactory.GetConnection().QueryAsync<Product>(
                    "select * from Product");
            }
        }
