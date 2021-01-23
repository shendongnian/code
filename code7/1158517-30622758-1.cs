    public partial class Foo : IVersionableDbObject<Foo>
    {
        public byte[] Version { get { return fooversion; } }
        public Expression<Func<Foo, bool>> LookupSelector
        {
            get { return foo => foo.FooId == FooId && foo.fooversion == Version; }
        }
    }
