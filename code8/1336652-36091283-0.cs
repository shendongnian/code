    public abstract class ContextBase
    {
        protected virtual void Act()
        {
        }
        protected virtual void Arrange()
        {
        }
        protected virtual void Cleanup()
        {
        }
        [TearDown]
        public void TestCleanup()
        {
            this.Cleanup();
        }
        [SetUp]
        public void TestInit()
        {
            this.Arrange();
            this.Act();
        }
    }
    public class ControllerTests : ContextBase
    {
        private Controller _controller;
        protected override void Arrange()
        {
            _controller = new Controller();
        }
        private class WhenUserIdExistsInSession : ControllerTests
        {
            protected override void Arrange()
            {
                base.Arrange();
                //Preconditions...
            }
            private class WhenUserExistsInDb : WhenUserIdExistsInSession
            {
                protected override void Arrange()
                {
                    base.Arrange();
                    //Preconditions...
                }
                private class WhenCompanyIdExistsInSession : WhenUserExistsInDb
                {
                    protected override void Arrange()
                    {
                        base.Arrange();
                        //Preconditions...
                    }
                    private abstract class WhenCompanyExistsInDb : WhenCompanyIdExistsInSession
                    {
                        protected override void Arrange()
                        {
                            base.Arrange();
                            //Preconditions...
                        }
                        protected override void Act()
                        {
                            _controller.GetCompanyReport();
                        }
                        [Test]
                        public void SomeGranularUnitTestForReport_1()
                        {
                            //Some stuff.. 
                        }
                        [Test]
                        public void SomeGranularUnitTestForReport_2()
                        {
                            //Some stuff.. 
                        }
                        [Test]
                        public void SomeGranularUnitTestForReport_3()
                        {
                            //Some stuff.. 
                        }
                        [TestFixture]
                        public class WhenCompanyIsKindaSpecial : WhenCompanyExistsInDb
                        {
                            protected override void Arrange()
                            {
                                base.Arrange();
                                //Preconditions...
                            }
                        }
                        [TestFixture]
                        public class WhenCompanyIsTotallyNormal : WhenCompanyExistsInDb
                        {
                            protected override void Arrange()
                            {
                                base.Arrange();
                                //Preconditions...
                            }
                        }
                    }
                }
            }
        }
    }
