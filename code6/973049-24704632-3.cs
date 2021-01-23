    internal class ProductReaderMap : IResultSetMapper<Product>
    {
    	public async Task<List<Product>> MapSetAsync(IDataReader reader)
    	{
    		List<Product> results = new List<Product>();
    		using(reader)
    		{
              results.Add(new Product
              {
                ProductId = r.GetInt32(0),
                ProductName = r.GetString(1),
                SupplierId = r.GetInt32(2),
                UnitsInStock = r.GetInt16(3)
              });
    		}
        return results;
    	}
    }
