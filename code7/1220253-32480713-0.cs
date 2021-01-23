    internal class Program {
        private static void Main(string[] args) {            
            // suppose it's from another assembly, and you don't have direct reference to type
            var c = Activator.CreateInstance(typeof(MyClass)); 
            IMyClass iface = c.ActLike<IMyClass>();
            iface.method1();
            Console.ReadKey();
        }
    }
    public class MyClass
    {
        public void method1() {
            Console.WriteLine("Method 1");
        }
        public void method2() {
            Console.WriteLine("Method 2");
        }
    }
    public interface IMyClass {
        void method1();
        void method2();
    }
