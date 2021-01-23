    string expression = @"using System;  
    namespace MyNamespace {
        public class MyClass {
            public static int DoStuff(CustomClass myCustomClass) {
                return myCustomClass.X + myCustomClass.Y;
            }
        }
        public class CustomClass
        {
            public int X;
            public int Y;
            public CustomClass(int x, int y) { X = x; Y = y; }
        }
    }";
    CSharpCodeProvider provider = new CSharpCodeProvider();
    CompilerParameters assemblies = new CompilerParameters(new string[] { "System.dll" });
    CompilerResults results = provider.CompileAssemblyFromSource(assemblies, expression);
    Type temporaryClass = results.CompiledAssembly.GetType("MyNamespace.MyClass");
    Type parClass = results.CompiledAssembly.GetType("MyNamespace.CustomClass");
    MethodInfo temporaryFunction = temporaryClass.GetMethod("DoStuff");
    object mc = parClass.GetConstructor(new Type[] { typeof(int), typeof(int) }).Invoke(new object[]{1,2});
    object result = temporaryFunction.Invoke(null, new object[] { mc });
