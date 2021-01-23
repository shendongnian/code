    public class TestClass
    {
        private Func<FooBase> m_FooBaseFactory;
        public TestClass(Func<FooBase> factory)
        {
            m_FooBaseFactory = factory;
        }
        public void TestMethod()
        {
            var foo = m_FooBaseFactory();
            //consume foo here
        }
    }
