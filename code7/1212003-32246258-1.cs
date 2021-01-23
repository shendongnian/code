    [TestClass]
    public class MyMethodTest
    {
		[TestMethod]
		public void MyMethod_WhenCalled_PartialViewIsReturned()
		{
			// Arrange
			// The magic I need to happen.
			var controller = new TestableHomeController { UseFakeAttributes = true };
			// Act
			var result = controller.MyMethod() as PartialViewResult;
			// Assert
			var model = result.Model;
			Assert.AreEqual("MyFakeTitle1.0.0.0", model); // currently static, need to verify against a mock
		}
    
    	private class TestableHomeController : HomeController
    	{
    		public bool UseFakeAttributes { get; set; }
    
    		public override IEnumerable<Attribute> GetCustomAttributes(Type attributeType)
    		{
    			return UseFakeAttributes
    				? new List<Attribute>
    					{
    						new AssemblyTitleAttribute("MyFakeTitle"),
    						new AssemblyVersionAttribute("1.0.0.0"),
    						new AssemblyDescriptionAttribute("Assembly fake description")
    						// next attributes ...
    					}
    				: base.GetCustomAttributes(attributeType);
    		}
    	}
    }
