    [TestFixture]
    public class FooContextActionTests  : CSharpContextActionExecuteTestBase<FooContextAction>
    {
    	protected override string ExtraPath => "FooContextActionTests";
    
    	protected override string RelativeTestDataPath => "FooContextActionTests";
    
    	[Test]
    	public void Test01()
    	{
    		DoTestFiles("Test01.cs");
    	}
    }
