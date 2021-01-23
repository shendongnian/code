    public interface IMyType { void method(); }
    public class MyType: IMyType {
        public virtual void method() { Console.WriteLine("method"); }
        public virtual void method2() { Console.WriteLine("method2"); }
    }
    public class MyInterceptor : MethodInterceptor
    {
        protected override void PreProceed(IInvocation invocation)
        {
            Console.Write("before - ");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MyType>()
                .As<IMyType>()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(MyInterceptor));
            builder.RegisterType<MyInterceptor>()
                .AsSelf();
            var container = builder.Build();
            
            var otherBuilder = new ContainerBuilder();
            otherBuilder.RegisterType<MyType>()
                .AsSelf()
                .As<IMyType>()
                .EnableClassInterceptors()
                .InterceptedBy(typeof(MyInterceptor));
            otherBuilder.RegisterType<MyInterceptor>()
                .AsSelf();
            var otherContainer = otherBuilder.Build();
            container.Resolve<IMyType>().method();
            // outputs -> before - method
            otherContainer.Resolve<IMyType>().method();
            // outputs -> before - method
            otherContainer.Resolve<MyType>().method();
            // outputs -> before - method
            otherContainer.Resolve<MyType>().method2();
            // outputs -> before - method2
        }
    }
