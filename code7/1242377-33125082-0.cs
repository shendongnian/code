    using System;
    namespace Spacelabs.WcfDuplexDemo.Client
    {
        static class Program
        {
            static void Main()
            {
                var myClass = new MyClass(() => new MyConcreteClass());
                myClass.DoSomething();
            }
        }
        public interface IMyInterface
        {
            string MyMethod(int param);
        }
        public sealed class MyConcreteClass : IMyInterface
        {
            public string MyMethod(int param)
            {
                return param.ToString();
            }
        }
        public sealed class MyClass
        {
            private readonly Func<IMyInterface> createMyInterface;
            public MyClass(Func<IMyInterface> createMyInterface)
            {
                this.createMyInterface = createMyInterface;
            }
            public void DoSomething()
            {
                // Instead of var item = new MyConcreteClass(), we do the following:
                var item = createMyInterface();
                Console.WriteLine(item.MyMethod(12345));
            }
        }
