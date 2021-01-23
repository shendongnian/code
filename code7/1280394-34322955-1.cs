    public class TestClass
    {
        private Func<FooBase> m_FooBaseFactory;
        public Test(Func<FooBase> factory)
        {
            m_FooBaseFactory = factory;
        }
        public void TestMethod()
        {
            var foo_base = m_FooBaseFactory();
            //consume foo_base here
        }
    }
