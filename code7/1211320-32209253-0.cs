    public class MyEnumerable : IEnumerable<MyClass>
    {
        private readonly IEnumerable<MyClass> items;
        public MyEnumerable(IEnumerable<MyClass> items)
        {
            this.items = items;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public IEnumerator<MyClass> GetEnumerator()
        {
            return items.GetEnumerator();
        }
        public MyEnumerable Where(Func<MyClass, bool> predicate)
        {
            return new MyEnumerable(items.Where(predicate));
        }
    }
