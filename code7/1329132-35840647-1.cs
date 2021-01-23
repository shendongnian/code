    public class Program
    {
        public static void Main()
        {
            var program = new Program();
            Try("A", program.A);
            Try("B", program.B);
            Try("C", program.C);
            Console.ReadKey();
        }
        private static void Try(string name, Func<Action> generator)
        {
            var mi = generator().Method;
            Console.WriteLine($"{name}: DeclaringType={mi.DeclaringType}, Attributes={mi.Attributes}");
        }
        private Action A() => () => { };
        private Action B() => () => { ToString(); };
        private Action C()
        {
            var c = 1;
            return () => c.ToString();
        }
    }
