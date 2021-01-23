    [TestFixture]
    public class Implementation1Tests : BaseMyInterfaceImplementationTest 
    {
    	[SetUp]
    	public void BaseTestInitialize()
    	{
    		ClassUnderTest = new Implementation1();
    	}
    }
