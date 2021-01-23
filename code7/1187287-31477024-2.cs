    public class MsSqlStoreRepository : IStoreRepository
    {
        private string ConnectionString { get; set; }
    
        public MsSqlStoreRepository(string connectionString)
        {
            ConnectionString = connectionString;
    	}
    
        public List<Product> GetAllProducts()
        {
            var command = new SqlCommand("select id, name, description, price from products");
            var dt = MsSqlDatabaseHelpers.GetDataTable(command, ConnectionString);
            return dt.AsEnumerable().Select(r => GenerateProductFromDataRow(r)).ToList();
        }
    }
