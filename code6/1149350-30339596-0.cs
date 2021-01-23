    public class Foo : IHasIntId
    {
        [AutoIncrement]
        public int Id { get; set; }
        [Reference]
        public Bar Bar { get; set; }
        public string Name { get; set; }
    }
