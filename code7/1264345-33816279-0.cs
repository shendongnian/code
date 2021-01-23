    void Main()
    {
    	var test = new Test();
    	test.Property = "5";
    	Console.WriteLine(test.Property);//5
	
    	FieldInfo fieldInfo = test.GetType().GetField("_property",BindingFlags.NonPublic | BindingFlags.Instance);
	    fieldInfo.SetValue(test, null);
	    Console.WriteLine(test.Property);//null
    }
    public class Test
    {
    	private string _property = string.Empty;
	    public string Property
	    {
		    get { return _property; }
		    set { _property = value ?? string.Empty; }
	    }
    }
