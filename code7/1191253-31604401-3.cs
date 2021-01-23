    // Using MyClass
    Type objType = Type.GetType("VsLogAnalyzer." + "MyClass");
    MyInterface myObj = Activator.CreateInstance(objType) as MyInterface;
    myObj.showData();
    // Using MyClass2
    objType = Type.GetType("VsLogAnalyzer." + "MyClass2");
    myObj = Activator.CreateInstance(objType) as MyInterface;
    myObj.showData();
