    [ClassInterface(ClassInterfaceType.None)]
    [Guid("19172E3D-F21F-4222-8F68-9D54C4380F20")]
    [ComVisible(true)]
    public class ExampleClass
    {
        public ExampleClass()
        {}
        
        public string Name { get; set; }
        public string Value { get; set; }
    }
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("29172E3D-F21F-4222-8F68-9D54C4380F21")]
    [ComVisible(true)]
    public class ExampleClass2
    {
        public ExampleClass2()
        {}
        
        public string UpperString { get; set; }
    }
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("39172E3D-F21F-4222-8F68-9D54C4380F22")]
    [ComVisible(true)]
    public class CSharpFunctor
    {
        public CSharpFunctor()
        {}
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
    
