    class MyClass 
    { 
        public int Foo { get; set; } 
        public int Bar { get; set; } 
    }
 
    var coll = new[] { new MyClass { Foo = 1, Bar = 2 } };
    var enu = coll.Select<MyClass, ???>(x => new { Bar = x.Foo }).ToList();
