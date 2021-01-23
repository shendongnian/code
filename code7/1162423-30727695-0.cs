    public sealed class FooComparer : IEqualityComparer<Foo>
    {
        public bool Equals(Foo x, Foo y)
        {
            return x.FooId == y.FooId && x.FooField == y.FooField;
        }
        public int GetHashCode(Foo foo)
        {
            // Note that if FooField can be null, you'll need to account for that...
            return foo.FooId ^ foo.FooField.GetHashCode();
        }
    }
