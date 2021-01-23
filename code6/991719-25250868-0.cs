    System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
    parameters.GenerateExecutable = false;            
    parameters.OutputAssembly = @"C:\myclass.dll";
    parameters.ReferencedAssemblies.Add("System.dll");//Add reference
    
    string code = @"
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    
    namespace First
    {
        public class B
        {
            public List<string> list = new List<string>();
    
            [DisplayName(""Pos""),Category(""Test""),DefaultValue(0)]
            public int Position { get; set; }
        }
    }
    ";
    CompilerResults r = CodeDomProvider.CreateProvider("CSharp").CompileAssemblyFromSource(parameters, code);
    if (r.Errors.Count <= 0)
    {
        var DLL = Assembly.LoadFile(parameters.OutputAssembly);
        foreach (Type type in DLL.GetExportedTypes())
        {
            dynamic c = Activator.CreateInstance(type);
            _props.SelectedObject = c;
        }
    }
