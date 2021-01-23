    public class Bar
    {
        public List<Foo> Lst { get; set; }
        public Bar()
        {
            Lst = new List<Foo>();
            Lst.Add(new Foo { Name = "111" });
            Lst.Add(new Foo { Name = "222" });
            Lst.Add(new Foo { Name = "333" });
            Lst.Add(new Foo { Name = "444" });
            Lst.Add(new Foo { Name = "555" });
        }
    }
