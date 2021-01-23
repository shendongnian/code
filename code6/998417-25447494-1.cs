        public abstract class TestFixtureSetupClass
        {
            [TestFixtureSetUp]
            public void init()
            {
                myRandomMethod();
            }
            public virtual void myRandomMethod() { }
        }
