    interface IFirstInterface
    {
        bool IsReal(); 
    }
    interface ISecondInterface
    {
        bool IsReal();
    }
    
    public class ExampleClass : IFirstInterface, ISecondInterface
    {
        // will be used for IFirstInterface
        bool IFirstInterface.IsReal(){}
        // will be used for ISecondInterface
        public bool IsReal(){}
    }
