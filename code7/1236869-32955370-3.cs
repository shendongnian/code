    public class A 
    {
    	public int Val1 { get; set; }
    }
    // Somewhere in your app...
    dynamic expando = new ExpandoObject();
	expando.Val1 = 11;
		
    // Now you got a new instance of A where its Val1 has been set to 11!
	A instanceOfA = ((ExpandoObject)expando).ConvertFromExpando<A>();
    
