    using System;
    using System.Runtime.Loader;
    namespace TestApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                var myAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(@"C:\Documents\Visual Studio 2017\Projects\Foo\Foo\bin\Debug\netcoreapp2.0\Foo.dll");
                var myType = myAssembly.GetType("Foo.FooClass");
                dynamic myInstance = Activator.CreateInstance(myType);
                myInstance.UpperName("test");
            }
        }
    }
