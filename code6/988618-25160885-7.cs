    string path = @"MyBootstrapper.dll";
    var assembly = AppDomain.CurrentDomain.Load(path);
    // to do something with the assembly
    var type = assembly.GetType("MyBootstrapper.Bootstrapper");
    var method = type.GetMethod("Run", BindingFlags.Static);
    method.Invoke(null, null);
    // or if the Run method has one parameter of "string" type
    var method = type.GetMethod("Run", BindingFlags.Static, Type.DefaultBinder, new[] { typeof(string) }, null);
    method.Invoke(null, new object[] { "Parameter to run" });
