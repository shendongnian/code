    using System;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Loader;
    using Microsoft.Extensions.DependencyModel;
    
    namespace AssemblyLoadingDynamic
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var asl = new AssemblyLoader();
                var asm = asl.LoadFromAssemblyPath(@"C:\Location\Of\" + "SampleClassLib.dll");
    
                var type = asm.GetType("MyClassLib.SampleClasses.Sample");
                dynamic obj = Activator.CreateInstance(type);
                Console.WriteLine(obj.SayHello("John Doe"));
            }
    
            public class AssemblyLoader : AssemblyLoadContext
            {
                // Not exactly sure about this
                protected override Assembly Load(AssemblyName assemblyName)
                {
                    var deps = DependencyContext.Default;
                    var res = deps.CompileLibraries.Where(d => d.Name.Contains(assemblyName.Name)).ToList();
                    var assembly = Assembly.Load(new AssemblyName(res.First().Name));
                    return assembly;
                }
            }
        }
    }
