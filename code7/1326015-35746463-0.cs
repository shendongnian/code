    void Main()
    {
    	//Create disposable WebClient
    	using (var client = new WebClient())
    	{
    		//Get list of dynamic parameters
    		string param = "value";
    		
    		//Use WebClient to Download the response as Json String
    		var result = client.DownloadString("http://api.service.com/path/here/?param=" + param);
    		
    		//Deserialize JSON using Newtonsoft.Json
    		MyClass obj = JsonConvert.DeserializeObject<MyClass>(result);
    		
    		//Save Object to Db
    		SaveToDb(obj);
    	}
    }
    public void SaveToDb(MyClass obj)
    {
    	//Use whatever persistence you prefer
    	using (var context = new DataContext())
    	{
    		context.MyClasses.Add(obj);
    		context.SubmitChanges();
    	}
    }
    
    // Define other methods and classes here
    class MyClass
    {
    	public int MyClassID { get; set; }
    	public string Name { get; set; }
    }
