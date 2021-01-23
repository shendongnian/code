    // creating an instance without executing the constructor
    MyClass myClass = (MyClass)FormatterServices.GetUninitializedObject(typeof(MyClass));
    // setting the read-only field
    myClass.GetType().GetField("_dependency", BindingFlags.NonPublic | BindingFlags.Instance)
        .SetValue(myClass, new MyDependency());
    // invoking the constructor on the already existing myClass
    ConstructorInfo ctor = typeof(MyClass).GetConstructor(
        BindingFlags.NonPublic | BindingFlags.Instance, null, Type.EmptyTypes, null);
    MethodInfo mi = typeof(RuntimeMethodHandle).
        GetMethod("InvokeMethod", BindingFlags.NonPublic | BindingFlags.Static);
    object signature = ctor.GetType().GetProperty(
        "Signature", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(ctor);
    mi.Invoke(null, new []{myClass, null, signature, false});
     
