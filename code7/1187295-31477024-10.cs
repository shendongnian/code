    //This will have methods for getting models from the database and also inserting and updating them (not shown)
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
        //I abstracted this logic out so we could reuse it elsewhere
        private Product GenerateProductFromDataRow(DataRow row)
        {
            return new Product()
            {
                Id = row.Field<int>("id"),
                Name = row.Field<string>("name"),
			    Description = row.Field<string>("description"),
			    Price = row.Field<double>("price")
		    };
	    }
    }
