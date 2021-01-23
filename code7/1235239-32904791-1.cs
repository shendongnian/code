    private static void Main(string[] args)
    {
        Mapper.CreateMap<Foo, FooBar>();
        List<Foo> randomFoos = new List<Foo>();
        for (int i = 0; i < 10; i++)
        {
            randomFoos.Add(new Foo());
        }
        Console.WriteLine("### Random foos");
        randomFoos.ForEach(Console.WriteLine);
        Console.WriteLine("### Converted foos");
        Mapper.Map<List<FooBar>>(randomFoos)
                .ForEach(Console.WriteLine);
    }
    public class Foo
    {
        public Foo()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Name = Guid.NewGuid().ToString("n")
                            .Substring(6);
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            this.GetType()
                .GetProperties()
                .ToList()
                .ForEach(property => builder.AppendLine(string.Format("{0}: {1}", property.Name, property.GetValue(this))));
            builder.AppendLine();
            return builder.ToString();
        }
    }
    public class FooBar : Foo
    {
        public FooBar()
        {
            this.Description = Guid.NewGuid().ToString()
                                    .Substring(12);
        }
        public string Description { get; set; }
    }
