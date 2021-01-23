    using System.Reflection;
    ...
    var asm = typeof(Foo).GetTypeInfo().Assembly;
    var type = asm.GetType(typeName);
    var instance = Activator.CreateInstance(type);
