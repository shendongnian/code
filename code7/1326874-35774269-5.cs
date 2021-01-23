    TestA _testA = new TestA(); // OK
    TestB _testB = new TestB(); // ERROR
    
    int debugA = new TestA().a1 // ERROR
    int debugB = new TestA().GetA1(); // OK
    
    TestB testB_ = new TestA().GetBase(); // ERROR
