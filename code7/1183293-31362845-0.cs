    public class TestClass : ClassToBeTested
    {
        public TestClass(IMyDependencie mockDependency)
        {
            // Set protected property:
            MyDependency = mockDependency;
        }
    }
