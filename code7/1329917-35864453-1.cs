    public class MyModuleTest
    {
        private IContainer container;
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            var containerBuilder = new ContainerBuilder();
            // register module to test
            containerBuilder.RegisterModule<MyModule>(); 
            // don't start startable components - 
            // we don't need them to start for the unit test
            this.container = containerBuilder.Build(
                ContainerBuildOptions.IgnoreStartableComponents);
        }
        [TestCaseSource(typeof(TypesExpectedToBeRegisteredTestCaseSource))]
        public void ShouldHaveRegistered(Type type)
        {
            this.container.IsRegistered(type).Should().BeTrue();
        }
        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            this.container.Dispose();
        }
        private class TypesExpectedToBeRegisteredTestCaseSource : IEnumerable<object[]>
        {
            private IEnumerable<Type> Types()
            {
                // whatever types you're registering..
                yield return typeof(string);
                yield return typeof(int);
                yield return typeof(float);
            }
            public IEnumerator<object[]> GetEnumerator()
            {
                return this.Types()
                    .Select(type => new object[] { type })
                    .GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
