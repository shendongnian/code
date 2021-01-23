    // writes Foo1
    Console.Out.WriteLine(foo1.Message);
    // writes Foo2
    Console.Out.WriteLine(foo2.Message);
    // writes foo1 bar called
    foo1.RunBar();
    // writes foo2 bar called
    foo2.RunBar();
    // does nothing
    Foo.RunBar();
