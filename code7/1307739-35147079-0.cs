    class Foo {
        public int A {get;set;}
        public string B {get;set;}
    }
    ...
    Foo foo = new Foo {A = 1, B = "abc"};
    foreach(var prop in foo.GetType().GetProperties()) {
        Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(foo, null));
    }
