    class Program
    {
        interface IDoSomething<T>
        {
            void DoSomething(T param);
        }
        class Test : IDoSomething<int>, IDoSomething<string>
        {
            public void DoSomething(int param)
            {
                
            }
            public void DoSomething(string param)
            {
                
            }
        }
        static void Main(string[] args)
        {
            DoSomething(4);
        }
        static void DoSomething<T>(T param)
        {
            var test = new Test();
            var cast = test as IDoSomething<T>;
            if (cast == null) throw new Exception("Unhandled type");
            cast.DoSomething(param);
        }
    }
