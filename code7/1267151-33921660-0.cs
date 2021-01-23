    var foos = new List<Foo>
                {
                    new Foo {Bars = new List<Bar> {new Bar { Bazs = new List<Baz> { new Baz { Quxs = new List<Qux> { new Qux()} } } } } },
                    new Foo {Bars = new List<Bar> {new Bar { Bazs = new List<Baz> { new Baz { Quxs = new List<Qux> { new Qux()} } } } } },
                     new Foo {Bars = new List<Bar> {new Bar { Bazs = new List<Baz> { new Baz { Quxs = new List<Qux> { } } } } } },
    
                };
    
                var r = foos.Where(f => f.Bars.All(bars=>bars.Bazs.All(baz=>baz.Quxs.Any()))).ToList();
     class Foo
    {
        public List<Bar> Bars { get; set; }
    }
    class Bar
    {
        public List<Baz> Bazs { get; set; }
    }
    class Baz
    {
        public List<Qux> Quxs { get; set; }
    }
    class Qux { }
