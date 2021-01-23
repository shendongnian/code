    void Main()
    {
    	var content = new Content();
    
    	System.Reflection.MethodInfo[] methods = typeof(Content).GetMethods(
            System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
        foreach (System.Reflection.MethodInfo m in methods)
        {
    		Response.Write(m.Invoke(content, null).ToString());
    	}
    }
    
    public class Content
    {
    	public static void Test1() {}
    	public static void Test2() {}
    }
