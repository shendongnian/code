    Assembly assembly = Assembly.LoadAssembly("AnotherAssemblyFile");
    Type[] assemblyTypes = assembly.GetTypes();
    Type ISampleType = assemblyTypes.GetType("NameSpace.ISample");
    Type sampleType = assemblyTypes.Single(type => 
                      (type != ISampleType) && ISampleType.IsAssignableFrom(type));
    object instance = Activator.CreateInstance(sampleType);
    MethodInfo mi = sampleType .GetMethod("SampleMethod");
    var result = mi.Invoke(instance, new object[]{"you will see me"});
