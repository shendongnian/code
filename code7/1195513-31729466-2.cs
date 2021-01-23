    SomeClass test = new SomeClass();
    test.Method0();// Calls overriden Method0
    test.Method1();// Calls overriden Method1
    test.Method2();// Calls new Method2
    BaseClass test2 = new SomeClass();
    test2.Method0();// Calls overriden Method0
    test2.Method1();// Calls overriden Method1
    test2.Method2();// Calls BaseClass's Method2
