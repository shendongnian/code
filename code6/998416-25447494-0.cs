        [SetUpFixture]
        public class TestFixtureSetupClass
        {
            [SetUp]
            public void init()
            {
                myRandomMethod();
            }
            public virtual void myRandomMethod() { }
        }
