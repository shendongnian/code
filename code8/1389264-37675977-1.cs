    public class TestClass
    {
        private static string _testStaticString;
    	private string _testInstanceString;
    	
        public void TestClass()
        {
    		_testStaticString = "Test"; //Works just fine
    		_testInstanceString = "Test";
    		
    		TestStatic();
        }
    	
    	private static void TestStatic()
    	{
    		_testInstanceString = "This will not work"; //Will not work because the method is static and belonging to the type it cannot reference a string belonging to an instance.
    		_testStaticString = "This will work"; //Will work because both the method and the string are static and belong to the type.
    	}
    }
