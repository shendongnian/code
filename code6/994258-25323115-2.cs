        var csc = new CSharpCodeProvider();
        var parameters = new CompilerParameters(new[] { "mscorlib.dll", "System.Core.dll" }, "foo.exe", true);
        parameters.GenerateExecutable = false;
        parameters.GenerateInMemory = true;
    
