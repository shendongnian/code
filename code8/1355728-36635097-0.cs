    public class GenericTest
    {
        public IEnumerable<T> CalleeMethod<T>() where T : class
        {
            return new List<T>();
        }
    }
    [TestMethod]
    public void IEnumberableT()
    {
        var x = new GenericTest();
        IEnumerable<string> result = x.CalleeMethod<string>();
    }
