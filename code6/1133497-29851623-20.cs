    public class Program
    {
    	public static void Main()
    	{
    		var json = @"
    {'EmailItems':[
        {'EmailSubject_Id':16,'IsSubject':true,'Email_String':'Cube Build Successful','StatusCode':0},
        {'EmailSubject_Id':17,'IsSubject':true,'Email_String':'Cube Build Failure','StatusCode':0}
    ]}";
    		var p = new Program();
    		p.SetAllStatusRules(json);
    	}
    
    	public bool SetAllStatusRules(string ruleList)
    	{
    		SystemStatusRules subjectRules = JsonConvert.DeserializeObject<SystemStatusRules>(ruleList);
    		Console.WriteLine(subjectRules.EmailItems.Count.ToString());
    		Console.WriteLine(subjectRules.EmailItems[0].Email_String);
    		return true;
    	}
    }
    
    public class SystemStatusRules
    {
    	public struct EmailItem
    	{
    		public int EmailSubject_Id;
    		public bool IsSubject;
    		public string Email_String;
    		public int StatusCode;
    	}
    	public List<EmailItem> EmailItems { get; set; }
    }
