    public class MyTestClass : IMyInterface
    {
        public IEnumerable<MyObject> Get()
        {
            List<MyObject> list = new List<MyObject>();
            // populate list
            return list;
        }        
    }
