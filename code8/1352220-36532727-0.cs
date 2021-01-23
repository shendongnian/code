    public class MyClass1 : IEnumerable
    {
        public void Add(int i) { }
        public IEnumerator GetEnumerator() => null;
    }
    
    public class MyClass2 : IEnumerable
    {
        public void Add(double i) { }
        public IEnumerator GetEnumerator() => null;
    }
    
    public class MyClass3 : IEnumerable
    {
        public void Add(object i) { }
        public IEnumerator GetEnumerator() => null;
    }
