    [Obsolete]
    public class MyClass
    {
    }
    // Here the ObsoleteAttribute is created
    var att1 = typeof(MyClass).GetCustomAttributes(false)[0];
    // Here the ObsoleteAttribute is created again
    var att2 = typeof(MyClass).GetCustomAttributes(false)[0];
    // false!
    bool refeq = object.ReferenceEquals(att1, att2);
