    // Main, first assembly
    namespace ConsoleApplication1
    {
        public class B : IB
        {
            Action _action;
            public void AddAction(Action act)
            {
                _action = act;
            }
            public void Invoke()
            {
                Console.WriteLine(_action.Target);
                Console.WriteLine("Is public: {0}", _action.Method.IsPublic);
                _action();
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var a = new A();
                var b = new B();
                a.AddActionTo(b);
                b.Invoke();
                Console.ReadKey();
            }
        }
    }
