        [TestCleanup]
        public void CleanupTest()
        {
            _container.Dispose();
        }
        [TestMethod]
        public void ThingINeedFactory_CreatesExpectedType()
        {
            var factory = _container.Resolve<IThingINeedFactory>();
            var needsThing = new NeedsThing(factory);
            var output = needsThing.PerformSomeFunction(ThingTypes.B);
            Assert.AreEqual(output, typeof(ThingB).Name);
        }
        [TestMethod]
        public void ThingINeedFactory_CreatesDefaultyTpe()
        {
            var factory = _container.Resolve<IThingINeedFactory>();
            var needsThing = new NeedsThing(factory);
            var output = needsThing.PerformSomeFunction(ThingTypes.D);
            Assert.AreEqual(output, typeof(ThingC).Name);
        }
    }
