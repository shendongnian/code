    public class EntityHelper
    {
    	private readonly Context _context;
    	public EntityHelper(Context context)
    	{
    		this._context = context;
    	}
    
    	public string GetName<T>(int id)
    	{
    		return this._context.Set<T>().Where(x => x.id == id).FirstOrDefault.Name;
    	}
    }
