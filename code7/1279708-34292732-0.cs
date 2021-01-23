    public class Foo
    {
    	private IService service;
    	public Foo(IService service)
    	{
    		this.service = service;
    	}
    	
    	public string GetData()
    	{
    		string outData;
    		service.DoSomething(out outData);
    		
    		return outData != "" ? outData : "There was no data";
    	}
    }
    
    [Test]
    public void FooTest_ServiceReturnsEmptyString()
    {
        var mock = new Mock<IService>();
        string expectedValue = "";
        mock.Setup(s => s.DoSomething(out expectedValue));
    
        var fooObj = new Foo(mock.Object);
    	var result = fooObj.GetData();
    	
        Assert.AreEqual("There was no data", result);
    }
    
    [Test]
    public void FooTest_ServiceReturnsValue()
    {
        var mock = new Mock<IService>();
        string expectedValue = "data";
        mock.Setup(s => s.DoSomething(out expectedValue));
    
        var fooObj = new Foo(mock.Object);
    	var result = fooObj.GetData();
    	
        Assert.AreEqual("data", result);
    }
