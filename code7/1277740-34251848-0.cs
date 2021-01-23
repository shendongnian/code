    [TestClass]
    public class TreeTest
    {
        private CompositionContainer _Container;
        private class Trees
        {
            public IEnumerable<ITree<int>> TreeInstances { get; set; }
        }
        [TestInitialize()]
        public void InitialTest()
        {
            ...
            //add the Export<Trees>() in your code
            registrationITreeBuilder.ForType<Trees>().ImportProperty(tt => tt.TreeInstances, ib => ib.AsMany()).Export<Trees>();
            ...
        }
        [TestMethod]
        public void TestMethod1()
        {
            var trees = _Container.GetExportedValue<Trees>();
        }
    }
