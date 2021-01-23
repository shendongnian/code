    [TestClass]
    public class MyMethodTest
    {
		[TestMethod]
		public void MyMethod_WhenCalled_PartialViewIsReturned()
		{
			// Arrange
			// The magic I need to happen.
            Mock<IDependency> dependencyStub = new Mock<IDependency>();
    		// dependencyStub.Setup(...).Returns(...);
    		var controller = new TestableHomeController(dependencyStub.Object)
            {
        		UseFakeAttributes = true
        	};
			// Act
			var result = controller.MyMethod() as PartialViewResult;
			// Assert
			var model = result.Model;
			Assert.AreEqual("MyFakeTitle1.0.0.0", model); // currently static, need to verify against a mock
		}
    
    	private class TestableHomeController : HomeController
    	{
    		public bool UseFakeAttributes { get; set; }
			public TestableHomeController(IDependency someDependency)
				:base(someDependency)
			{ }
    
    		public override IEnumerable<Attribute> GetCustomAttributes(Type attributeType)
    		{
    			return UseFakeAttributes
    				? new List<Attribute>
    					{
    						new AssemblyTitleAttribute("MyFakeTitle"),
    						new AssemblyVersionAttribute("1.0.0.0"),
    						new AssemblyDescriptionAttribute("Assembly fake description")
    						// next attributes ...
    					}.Where(a => a.GetType() == attributeType)
    				: base.GetCustomAttributes(attributeType);
    		}
    	}
    }
