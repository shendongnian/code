    class Program
    {
        static void Main(string[] args)
        {
            var o = new Foo { };
            var f = o.GetEntitiesWithPredicate(a => a.MyProperty.Where(b => b.MyProperty > 0).ToList().Count == 2); // f.MyProperty == 9 true
        }
    }
    class Foo
    {
        public ICollection<T> GetEntitiesWithPredicate(Expression<Func<T, bool>> predicate)
        {
            var t = predicate.Compile();
            var d = t.Invoke(new T { MyProperty = new List<Y> { new Y { MyProperty = 10 }, new Y { MyProperty = 10 } } });
            if (d) return new List<T> { new T { MyProperty = new List<Y> { new Y { MyProperty = 9 } } } };
            return null;
        }
    }
    class T
    {
        public T() { }
        public List<Y> MyProperty { get; set; }
    }
    class Y
    {
        public int MyProperty { get; set; }
    }
