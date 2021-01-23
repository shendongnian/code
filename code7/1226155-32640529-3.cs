     public class Program {
        private static void Main(string[] args) {
            ScriptEngine engine = Python.CreateEngine();            
            engine.Runtime.LoadAssembly(Assembly.LoadFile(@"path_to.dll"));
            // note how scope is created. 
            // "test" is just the name of python file from which dll was compiled. 
            // "test.py" > module named "test"
            var scope = engine.Runtime.ImportModule("test");
            // fetching global is as easy as this
            int g = scope.GetVariable("MyGlobal");
            // writes 5
            Console.WriteLine(g);
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
