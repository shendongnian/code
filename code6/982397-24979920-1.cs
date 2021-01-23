            string code = @"
                 using System;
                 using System.Reflection; 
                 namespace foo {
                     public class DynamicTypeA { }
                     public class DynamicTypeB {
                         public DynamicTypeA MyProperty { get; set; } 
                     }
                     public class DynamicTypeC {
                         public void Foo() {
                            foreach ( PropertyInfo pi in typeof(DynamicTypeB).GetProperties() )
                            {
                                Console.WriteLine( pi.PropertyType.Name );
                            }
                         } 
                     }
                 }       
            ";
            CSharpCodeProvider csp = new CSharpCodeProvider();
            CompilerParameters p = new CompilerParameters();
            p.GenerateInMemory = true;
            var results = csp.CompileAssemblyFromSource( p, code );
            var c = results.CompiledAssembly.CreateInstance( "foo.DynamicTypeC" );
            var typeC = c.GetType();
            typeC.InvokeMember( "Foo", BindingFlags.InvokeMethod | 
                BindingFlags.Public | BindingFlags.Instance, null, c, null );
