    public enum BaseJsonResponseTypes
    {
    	NotSet = 0,
    	Error = 1,
    	Success = 2
    }
    public class BaseJsonViewModel
    {
    	public BaseJsonResponseTypes Response { get; set; }
        public String Message { get; set; }
    }
    
    public class CategoryJsonViewModel : BaseJsonViewModel
    {
    	//Maybe you could include some implemention here.
    }
