    object ob = new TestClass();
    string str = (ob as TestClass).Str; // will work with casting.
    
    var ob = new TestClass(); // using a var across types.
    string str = ob.Str;
