    public class MyClass
    {
        readonly IContract _contract = null;
        public MyClass() {}
        public MyClass(IContract contract)
        {
            _contract = contract;
        }
        public void DoSomething()
        {
            _contract.MyMethod();
        }
    } 
    public class ConcreteContract : IContract
    {
        public ConcreteContract() { }
        public void MyMethod()
        {
            //do something;
            Debug.Print("Hello from the ConcreteContract class");
        }
    }
    public interface IContract
    {
        void MyMethod();
    }
    class Program
    {
        // add the nuget package Unity 1st
        // Install-Package Unity
        static void Main(string[] args)
        {
            // Declare a Unity Container -
            // normally done once in the Startup/init class
            var unityContainer = new UnityContainer();
            // Register IContract so when dependecy is detected
            // it provides a ConcreteContract instance
            unityContainer.RegisterType<IContract, ConcreteContract>();
            // Instance a MyClass class object through Unity
            var preferredClass = unityContainer.Resolve<MyClass>();
            preferredClass.DoSomething();
        }
    }
