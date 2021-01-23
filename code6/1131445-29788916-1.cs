        public sealed class TestProperties
        {
        	public static readonly TestProperties Account1 = new TestProperties((t, name) => t.Account1 == name);
        	public static readonly TestProperties Account2 = new TestProperties((t, name) => t.Account2 == name);
        	public static readonly TestProperties Account3 = new TestProperties((t, name) => t.Account3 == name);
 
    	private Func<TestClass, string, bool> _checkFunc;
    	
    	private TestProperties(Func<TestClass, string, bool> func)
    	{
    		_checkFunc = func;	
    	}
    	
    	
    	public bool IsApplicable(TestClass test, string name)
    	{
    		return _checkFunc(test, name);	
    	}
    }
