    using System;
    using System.Runtime.InteropServices;
    namespace CSharp
    {
        [Guid("62D276EB-FABE-4c0e-BF59-7D0799DEC029")]
        [ComVisible(true)]
        public interface IExampleClass
        {
            string Name { get; set; }
            int Value { get; set; }
        }
        [ClassInterface(ClassInterfaceType.None)]
        [Guid("4E196599-F1C5-4447-84F4-E46FC1C16105")]
        [ComVisible(true)]
        public class ExampleClass : IExampleClass
        {
            public ExampleClass()
            { }
            public string Name { get; set; }
            public int Value { get; set; }
        }
        [Guid("72D276EB-FABE-4c0e-BF59-7D0799DEC020")]
        [ComVisible(true)]
        public interface IExampleClass2
        {
            string UpperString { get; set; }
        }
        [ClassInterface(ClassInterfaceType.None)]
        [Guid("6712709D-8913-4911-8ABB-BFB4865D4E9F")]
        [ComVisible(true)]
        public class ExampleClass2 : IExampleClass2
        {
            public ExampleClass2()
            { }
            public string UpperString { get; set; }
        }
        [Guid("1C312E27-6B09-412c-B7AA-55F4E0FBCF8C")]
        [ComVisible(true)]
        public interface ICSharpFunctor
        {
            ExampleClass RunTheFunction(int ParameterValue);
            ExampleClass2 RunAnotherFunction(string ExampleString);
        }
        [ClassInterface(ClassInterfaceType.None)]
        [Guid("9B8FAFEA-64EB-493f-95CB-B0B0EDEBADC2")]
        [ComVisible(true)]
        public class CSharpFunctor : ICSharpFunctor
        {
            public CSharpFunctor()
            { }
            public ExampleClass RunTheFunction(int ParameterValue)
            {
                ExampleClass instance = new ExampleClass();
                instance.Name = "Stack Overflow";
                instance.Value = 1 + ParameterValue;
                return instance;
            }
            public ExampleClass2 RunAnotherFunction(string ExampleString)
            {
                ExampleClass2 instance = new ExampleClass2();
                instance.UpperString = ExampleString.ToUpper();
                return instance;
            }
        }
    }
    
