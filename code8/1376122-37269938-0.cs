    [TestMethod]
    public void TestMethod1()
    {
        var wasCalled = false;
        using (ShimsContext.Create())
        {
            ForMsFakes.Fakes.ShimDependency.AllInstances.Dispose = dependency =>
            {
                wasCalled = true;
            };
            var o = new ObjectUnderTest();
            o.Dispose();
        }
        Assert.IsTrue(wasCalled);
    }
      
    public class Dependency : IDisposable
    {
        public void Dispose() {}
    }
    
    public class ObjectUnderTest: IDisposable
    {
        private readonly Dependency _d = new Dependency();
    
        public void Dispose()
        {
            _d.Dispose();
        }
    }
