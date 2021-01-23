    A a = new A();
    a.x = new StringBuilder("Foo");
    B b = new B();
    b.y = a.x;
    b.y.Append("Bar");
    Console.WriteLine(a.x); // Prints FooBar
    a = null;
