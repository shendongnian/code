        static void Main( string[] args )
        {
            string code = @"
                 namespace foo {
                     public class DynamicTypeA { }
                     public class DynamicTypeB {
                         public DynamicTypeA MyProperty { get; set; } 
                     }
                 }       
            ";
            CSharpCodeProvider csp = new CSharpCodeProvider();
            CompilerParameters p = new CompilerParameters();
            p.GenerateInMemory = true;
            var results = csp.CompileAssemblyFromSource( p, code );
            foreach ( Type type in results.CompiledAssembly.GetTypes() )
            {
                Console.WriteLine( type.Name );
                foreach ( PropertyInfo pi in type.GetProperties() )
                {
                    Console.WriteLine( "\t{0}", pi.PropertyType.Name );
                }
            }
            Console.ReadLine();
        }
