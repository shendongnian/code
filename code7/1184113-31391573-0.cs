    // This class will be created inside your temporary appdomain.
    class MyClass : MarshalByRefObject
    {
        // This call will be executed inside your temporary appdomain.
        void ProcessAssemblies(string[] assemblyPaths)
        {
            // the assemblies are processed here
            foreach (var assemblyPath in assemblyPaths)
            {
                var asm = Assembly.LoadFrom(assemblyPath);
                ...
            }
        }
    }
