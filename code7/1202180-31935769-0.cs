    using System;
    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    
    namespace dynamicDll
    {
        class Programs
        {
            static void Mains(string[] args)
            {
                CompilerParameters parameters = new CompilerParameters();
                parameters.GenerateInMemory = true;
                parameters.GenerateExecutable = false;
                parameters.IncludeDebugInformation = true;
                parameters.OutputAssembly = "Dynamic.dll";
                var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                                .Where(a => !a.IsDynamic)
                                .Select(a => a.Location);
                parameters.ReferencedAssemblies.AddRange(assemblies.ToArray());
                var versionString = "1.0.0.0";
    
                CompilerResults cr = CodeDomProvider.CreateProvider("CSharp")
                    .CompileAssemblyFromSource(parameters, @"
    using System.Reflection;
    [assembly: AssemblyVersion(" + "\"" + versionString + "\"" + @")]                    
    namespace Dynamic
                        {
                            public class DynamicDllClass
                            {
                                public int X { get {return 7;}}
                            }
                        }");
    
                var instance = cr.CompiledAssembly.CreateInstance("Dynamic.DynamicDllClass");
                int x = (int) instance.GetType().GetProperty("X").GetGetMethod().Invoke(instance, null);
                Debug.Assert(x==7);
                Debug.Assert(cr.CompiledAssembly.FullName.Contains(versionString));
            }
        }
    }
