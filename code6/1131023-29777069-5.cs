    public class YourController : ApiController, IYourController
    {
    	 
    	IDataBase _db;
    	public PlayGroundController(IDataBase db)
    	{
    		_db = db;
    	}
