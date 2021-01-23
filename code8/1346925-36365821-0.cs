    namespace Testconsole {
    public class obj {
        public int myFunc(int value1, int value2 = 4, int value3 = 8) {
            return value1 + value2 + value3;
        }
    }
    class Program {
        static void Main(string[] args) {
            obj adder = new obj();
            Console.WriteLine(adder.myFunc(value1: 1, value3: 1));
            Console.ReadLine();
        }
    }
    }
