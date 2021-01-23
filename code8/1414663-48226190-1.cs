    class Program
    {
        static void Main(string[] args)
        {
            IEcho toWrap = new EchoImpl();
            IEcho decorator = DispatchProxy.Create<IEcho, GenericDecorator>();
            ((GenericDecorator)decorator).Wrapped = toWrap;
            ((GenericDecorator)decorator).Start = (tm, a) => Console.WriteLine($"{tm.Name}({string.Join(',', a)}) is started");
            ((GenericDecorator)decorator).End = (tm, a, r) => Console.WriteLine($"{tm.Name}({string.Join(',', a)}) is ended with result {r}");
            string result = decorator.Echo("Hello");
        }
        class EchoImpl : IEcho
        {
            public string Echo(string message) => message;
        }
        interface IEcho
        {
            string Echo(string message);
        }
    }
