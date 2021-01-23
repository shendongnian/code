    var csprovider = new CSharpCodeProvider(new Dictionary<string,string> {
        ["CompilerDirectoryPath"] = @"c:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\Roslyn",
    });
    options += " -langversion:8.0 ";
    var par = new CompilerParameters { GenerateInMemory = true, CompilerOptions = options };
    par.ReferencedAssemblies.Add("Microsoft.CSharp.dll");
    par.ReferencedAssemblies.Add("System.Core.dll");
    var res = csprovider.CompileAssemblyFromSource(par, "your C# code");
    return res.CompiledAssembly;// <- compiled result
