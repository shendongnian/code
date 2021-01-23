    public interface IEntity { } // Marker interface
    
    public interface IRepository<TEntity> where TEntity : IEntity 
    {
    	TEntity Get(object primaryKey);
    	
    	void Save(TEntity entity); // should handle both new and updating entities
    	
    	void Delete(TEntity entity);
    
    }
    
    public class ProductRepository : IRepository<Product> 
    {
    	public Product Get(object primaryKey) 
    	{
    		// Database method for getting Product
    	}
    	
    	public void Save(Product entity) 
    	{
    		// Database method for saving Product
    	}
    	
    	public void Delete(Product entity) 
    	{
    		// Database method for deleting Product
    	}
    }
