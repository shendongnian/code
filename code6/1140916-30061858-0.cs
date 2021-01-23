    void Main()
    {
    	var docInfo = new DocInfo{CustomerInfo = new CustomerInfo{ Name = "Todor", Address = "101 Local Drive", XXXXXX = "YYYYYY" }};
    	var docInfoJson = new JavaScriptSerializer().Serialize(docInfo);
    	docInfoJson.Dump();
    }
    
    // Define other methods and classes here
    public class DocInfo
    {
    	public CustomerInfo CustomerInfo {get;set;}
    }
    
    public class CustomerInfo
    {
    	public string Name {get;set;}
    	public string Address {get;set;}
    	public string XXXXXX {get;set;}
    }
