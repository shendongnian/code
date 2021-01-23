    class Foo
    {
        public string Name { get; set; }
        public double Number { get; set; }
    }
    List<Foo> myDict = new List<Foo>();
    myDict.Add(new Foo() { Name = "name1", Number = 0.0158 });
    myDict.Add(new Foo() { Name = "name2", Number = 0.0038 });
    myDict.Add(new Foo() { Name = "name3", Number = 0.0148 });
    var result = myDict.OrderBy(x => x.Number);
