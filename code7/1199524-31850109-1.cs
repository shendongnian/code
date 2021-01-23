    Assembly assembly = Assembly.LoadAssembly("AnotherAssemblyFile");
    Type[] assemblyTypes = assembly.GetTypes();
    Type ISampleType = assemblyTypes.Single(type => type.Name == "ISample" &&
                                                    type.IsInterface);
    Type sampleType = assemblyTypes.Single(type => ISampleType.IsAssignableFrom(type));
    object instance = Activator.CreateInstance(sampleType);
    MethodInfo mi = sampleType .GetMethod("SampleMethod");
    var result = mi.Invoke(instance, new object[]{"you will see me"});
