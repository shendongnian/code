    CompilerResults results = provider.CompileAssemblyFromSource(parameters, code);
    Assembly assembly = results.CompiledAssembly;
    Type program = assembly.GetType("Dynamic.Test");
    MethodInfo main = program.GetMethod("Test");
    main.Invoke(null, null);
