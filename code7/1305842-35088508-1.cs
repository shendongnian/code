    Imports System.Reflection
    ...
    Dim assembly As Assembly = Assembly.Load(...)
    Dim outerType As Type = assembly.GetType("Something")
    Dim field As FieldInfo = outerType.GetField("lala")
    Dim nestedType As Type = outerType.NestedType("Lala")
