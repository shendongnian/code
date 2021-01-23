    using System.Runtime.CompilerServices;
    class MyClass
    {
        [MethodImplAttribute(MethodImplOptions.NoOptimization)] 
        public void NonOptimizeMethod()
        {
            // Do some stuff
        }
    }
