    public interface IAccessorByName : IReadOnlyDictionary<string, object>
    {
        object this[string name] { get; set; }
    }
    public Foo : IAccessorByName
    {
        private static readonly IDictionary<string, Func<Foo, object>> getters = new Dictionary<string, Func<Foo, object>>
        {
            { "Id", (foo) => foo.Id },
            { "Name", (foo) => foo.Name },
        };
        private static readonly IDictionary<string, Action<Foo, object>> setters = new Dictionary<string, Action<Foo, object>>
        {
            { "Id", (foo, value) => { foo.Id = (int)value; } },
            { "Name", (foo, value) => { foo.Name = (string)value; } },
        };
        public int Id { get; set; }
        public string Name { get; set; }
        public object this[string name]
        {
           get { return getters[name](this); }
           set { setters[name](this, value); }
        }
    }
