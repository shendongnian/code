    class Program 
    {
    
    	public static Object MyMethod2(MyTextBox b) 
        {
    			return new Object();
    	}
    
    	static void Main(string[] args) 
        { 
    		Func<MyTextBox, Object> f3 = MyMethod2;
    
    		//This does not compile, and with cast you cannot make this work either.
    		Func<MyFrameworkElement, Object> f4 = f3;  // as Func<MyFrameworkElement, Object>; <- does not help
    	}
    }
