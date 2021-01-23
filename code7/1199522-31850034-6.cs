    Type[] types = Assembly
        .Load("AnotherAssembly")
        .GetTypes();
    Type sampleInterface = types
        .Single(f => f.Name == "ISample" && f.IsInterface == true);
    Type type = types
        .Single(t => t.GetInterfaces().Contains(sampleInterface));
    object instance = Activator.CreateInstance(type);
    MethodInfo method = type.GetMethod("SampleMethod");
    string result = (string) method.Invoke(instance, new object[] { "you will see me" });
