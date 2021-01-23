    public class ClientList : IDataRequest<Client>
    {
        public ICollection<Client> Fetch()
        {
            //do stuff
           return this.CreateCollection();
        }
    
        private ICollection<Client> CreateCollection()
        {
            List<Client> clientList = new List<Client>();
            // populate list
            return clientList;
        }
    }
    	
    public class ProductList : IDataRequest<Product>
    {
        public ICollection<Product> Fetch()
    	{
            //do stuff
           return this.CreateCollection();
        }
    
        private ICollection<Product> CreateCollection()
        {
            List<Product> productList = new List<Product>();
            // populate list
            return productList ;
        }
    }
