    public class A
    {
        protected List<int> list = new List<int>(Enumerable.Range(1, 10000000));
        public IReadOnlyList<int> GetList
        {
            get { return list; }
        }
    }
