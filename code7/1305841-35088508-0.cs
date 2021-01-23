    Imports System.Reflection
    ...
    Dim assembly As Assembly = Assembly.Load(...)
    Dim type As Type = assembly.GetType("Something")
    Dim field As FieldInfo = type.GetField("lala")
    Dim nestedType As Type = type.NestedType("Lala")
