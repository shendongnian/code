    // create compiler
    CodeDomProvider provider = CSharpCodeProvider.CreateProvider("C#");
    CompilerParameters options = new CompilerParameters();
    // add all loaded assemblies
    options.ReferencedAssemblies.AddRange(
        AppDomain.CurrentDomain.GetAssemblies().Where(item => !item.IsDynamic).Select(item => item.Location).ToArray());
    options.GenerateExecutable = false;
    options.GenerateInMemory = true;
    // source
    string source = "using System;namespace Test{public class Test{";
    source += "[Conditional()]public E3477 E3477 { get; private set; }";
    source += ...
    // compile
    CompilerResults result = provider.CompileAssemblyFromSource(options, source);
