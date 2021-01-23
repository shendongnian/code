    public class Program
    {
    	public static void Main()
    	{
    		Test t = new Test();
    		t.Click += Click_1;
    		t.CheckInvocationList();
    	}
    	
    	private static void Click_1(object sender, EventArgs e) {}
    }
    
    public class Test
    {
    	public event EventHandler Click;
    	
    	public void CheckInvocationList()
    	{
    		var t = Click;
    		if(t != null) 
    		{
    			var methods = t.GetInvocationList();
    			Console.WriteLine(methods.Length); // Output = 1
    		}
    	}
    }
