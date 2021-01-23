    public class MyClass<T> : IEnumerable<T> where T : class {
        public Func<T, bool> Filter { get; set; }
             = T => true; // default: no filter
        public List<T> mylist = new List<T>();
        public IEnumerator<T> GetEnumerator()
            => mylist.Where(Filter).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator()
            => mylist.Where(Filter).GetEnumerator();
    }
