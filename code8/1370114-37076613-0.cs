    void Main()
    {
    	var json = "{\r\n  \"model1\": {\r\n    \"$type\": \"MyType, MyAssembly\",\r\n    \"A\": 5\r\n  },\r\n  \"model2" +
    	    "\": {\r\n    \"C\": \"something\"\r\n}}";
    	var result = JsonConvert.DeserializeObject<Result>(json);
    }
    
    public class Result
    {
    	public MyType Model1 { get; set; }
    	public ExpandoObject Model2 { get; set;}
    }
    public class MyType { public int A { get; set;} }
