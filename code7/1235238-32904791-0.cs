    class Program
    {
        private static void Main(string[] args)
        {
            Mapper.CreateMap<Foo, FooBar>();
            List<Foo> randomFoos = new List<Foo>();
            for (int i = 0; i < 10; i++)
            {
                randomFoos.Add(new Foo());
            }
            Mapper.Map<List<FooBar>>(randomFoos)
                  .ForEach(f =>
                  {
                      Console.WriteLine(f.Id);
                      Console.WriteLine(f.Name);
                      Console.WriteLine(f.Description);
                  });
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
    }
