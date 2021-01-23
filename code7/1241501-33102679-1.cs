    namespace CLSCompliantAssembly
    {
        public class Class1
        {
            // This does NOT give a warning.
            public int MyTest1()
            {
                return (int) NonCLSCompliantAssembly.Class1.MyEnum.Red;
            }
            // This DOES give a warning.
            public NonCLSCompliantAssembly.Class1.MyEnum MyTest2()
            {
                return NonCLSCompliantAssembly.Class1.MyEnum.Red;
            }
        }
    }
