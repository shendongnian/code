    [TestClass]
    public class MyClassTests
    {
        [TestMethod]
        public void ProvideRequireLocationObject_EmptyCollection()
        {
            // arrange
            var providers = new ILocationProvider[] {};
            var obj = new MyClass(providers);
            // act
            var result = obj.ProvideRequireLocationObject();
            // assert
            Assert.IsNull(result);
        }
        [TestMethod]
        public void ProvideRequireLocationObject_NoRequiredLocation()
        {
            // arrange
            var providers = new ILocationProvider[] {
                new TestLocationProvider(false)
            };
            var obj = new MyClass(providers);
            // act
            var result = obj.ProvideRequireLocationObject();
            // assert
            Assert.IsNull(result);
        }
        [TestMethod]
        public void ProvideRequireLocationObject_OneRequiredLocation()
        {
            // arrange
            var providers = new ILocationProvider[] {
                new TestLocationProvider(true)
            };
            var obj = new MyClass(providers);
            // act
            var result = obj.ProvideRequireLocationObject();
            // assert
            Assert.AreEqual(providers[0], result);
        }
        [TestMethod]
        public void ProvideRequireLocationObject_OneRequiredLocationNotFirstInArray()
        {
            // arrange
            var providers = new ILocationProvider[] {
                new TestLocationProvider(false),
                new TestLocationProvider(true),
                new TestLocationProvider(false)
            };
            var obj = new MyClass(providers);
            // act
            var result = obj.ProvideRequireLocationObject();
            // assert
            Assert.AreEqual(providers[1], result);
        }
        [TestMethod]
        public void ProvideRequireLocationObject_MultipleRequiredLocations()
        {
            // arrange
            var providers = new ILocationProvider[] {
                new TestLocationProvider(true),
                new TestLocationProvider(true),
                new TestLocationProvider(true)
            };
            var obj = new MyClass(providers);
            // act
            var result = obj.ProvideRequireLocationObject();
            // assert
            Assert.AreEqual(providers[0], result);
        }
        public class TestLocationProvider : ILocationProvider
        {
            public TestLocationProvider(bool isRequiredLocation)
            {
                IsRequiredLocation = isRequiredLocation;
            }
            public bool IsRequiredLocation { get; private set; }
        }
    }
