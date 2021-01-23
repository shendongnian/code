    using System;
    using Autofac;
    public class Program
    {
        public static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MyService>()
                .OnActivating(e => e.Instance.SetMyDependency(new MyDependency()));
            
            var container = builder.Build();
            container.Resolve<MyService>();
        }
    }
    public class MyService
    {
        private MyDependency _myDependency;
        
        public void SetMyDependency(MyDependency myDependency)
        {
            _myDependency = myDependency;
            Console.WriteLine("SetMyDependency called");
        }
    }
    public class MyDependency
    {
    }
