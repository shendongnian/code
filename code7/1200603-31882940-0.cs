    public class FooModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<BarModel> Bars { get; set; }
        public FooModel(Guid id, string name, List<Bar> bars)
        {
            this.Id = id;
            this.Name = name;
            this.Bars = bars.Select(BarModel.From).ToList();
        }
        internal static FooModel From(Foo foo)
        {
            return new FooModel(foo.Id, foo.Name, foo.Bars);
        }
    }
