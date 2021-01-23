    public class MyDataObject { }
    
    public class UserObj { }
    
    public class DataManager
    {
    	public virtual MyDataObject GetMyDataObject(UserObj userObj, Guid guid)
    	{
    		throw new NotImplementedException();
    	}
    }
    
    class SUT
    {
    	public DataManager DataManager { get; private set; }
    	
    	public SUT(DataManager dataManager)
    	{
    		DataManager = dataManager;
    	}
    	
    	public void Method(UserObj userobj, Guid recordid)
    	{
    		var t = System.Threading.Tasks.Task.Factory.StartNew<MyDataObject>(()=>
    		{
    			return DataManager.GetMyDataObject(userobj, recordid);
    		});
    		
    		t.Wait();
    	}
    }
