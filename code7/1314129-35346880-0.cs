        public interface IBasicInterface
        {
            int Test();
        }
    
        public interface IAdvancedInterface : IBasicInterface
        {
            int Test();
        }
    
        public class AdvancedClass : IAdvancedInterface
        {
            int IBasicInterface.Test()
            {
                return 1;
            }
    
            int IAdvancedInterface.Test()
            {
                return 2;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                AdvancedClass tester = new AdvancedClass();
                Console.WriteLine(((IAdvancedInterface)tester).Test()); // returns 2
                Console.WriteLine(((IBasicInterface)tester).Test());    // returns 1
                Console.ReadLine();
            }
        }
