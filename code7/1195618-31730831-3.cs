    var f = new Foo();
    Console.WriteLine(f.SomeProperty);   // displays "foobar"
                                         // assuming we'd marked it public
    f.someField = "la";                  // assuming we'd made that public  too!
    Console.WriteLine(f.SomeProperty);   // displays "labar"
