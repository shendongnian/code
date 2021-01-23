    // result = MyClass
    var result = GetClassInterface(typeof(MyClass), typeof(IMyInterface));
    
    // result = MyClass
    var result = GetClassInterface(typeof(MyHighClass), typeof(IMyInterface));
    
    // result = PlainInheritedClass 
    var result = GetClassInterface(typeof(PlainInheritedClass), typeof(IMyInterface));
