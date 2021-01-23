    [TestClass]
    public class AnnoyingTestSomeOperationWrapper
    {
    
        [TestMethod]
        public void TestSpecificSomeOperationStuff() 
        {
            new TestSomeOperation().TestSpecificSomeOperationStuff()
        }
    
    }
    
    internal class TestSomeOperation : TestOperationCommon<SomeOperation, ...>
    {
        public void TestSpecificSomeOperationStuff() {}
    
    }
