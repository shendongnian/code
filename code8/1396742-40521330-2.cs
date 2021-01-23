    using System;
    using System.Runtime.Loader;
    
    namespace AssemblyLoadingDynamic
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var myAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(@"C:\MyDirectory\bin\Custom.Thing.dll");
                var myType = myAssembly.GetType("Custom.Thing.SampleClass");
                var myInstance = Activator.CreateInstance(myType);
            }
        }   
    }
