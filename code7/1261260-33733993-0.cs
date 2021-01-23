    void Main()
    {
    	var test = new Test() { User = new User() { Name = "1234", Age = 12}};
    	var js = Newtonsoft.Json.JsonConvert.SerializeObject(test);
    	
    	var t = Newtonsoft.Json.JsonConvert.DeserializeObject<Test>(js);
    }
    
    public class Test {
    	[Newtonsoft.Json.JsonProperty(PropertyName="/One")]
    	public User User {get;set;}
    }
    
    public class User{
    	public String Name {get;set;}
    	public int Age {get;set;}
    }
