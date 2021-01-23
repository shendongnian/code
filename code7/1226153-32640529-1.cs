     public class Program {
        private static void Main(string[] args) {
            ScriptEngine engine = Python.CreateEngine();            
            engine.Runtime.LoadAssembly(Assembly.LoadFile(@"path_to.dll"));
            // note how scope is created
            var scope = engine.Runtime.ImportModule("test");
            // how class type is grabbed
            var customerType = scope.GetVariable("Customer");
            // how class is created using constructor with name (note dynamic keyword also)
            dynamic customer = engine.Operations.CreateInstance(customerType, "Customer Name");
            // calling method on dynamic object
            var balance = customer.deposit(10.0m);
            // this outputs 10, as it should
            Console.WriteLine(balance);
            Console.ReadKey();
        }
    }
