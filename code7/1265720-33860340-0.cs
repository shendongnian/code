    public class A
    {
        protected List<int> list = new List<int>(10000000);
        public IReadOnlyList<int> GetList
        {
            get { return list; }
        }
    }
