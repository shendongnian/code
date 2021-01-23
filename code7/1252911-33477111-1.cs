    [TestClass]
    public class M
    {
    	[TestMethod]
    	public void X()
    	{
    		var myService = new MyService();
    		myService.FetchSomeDataAsync().Result; // Will this deadlock?
    	}
    }
