    public interface IEventuallyRegistered { void test(); }
    public class DefaultRegistration : IEventuallyRegistered { public void test() { } }
    public class EventuallyRegisteredInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation) { invocation.Proceed(); }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = new Castle.Windsor.WindsorContainer();
            container.Register(Component.For<EventuallyRegisteredInterceptor>());
            container.Register(Component.For<IEventuallyRegistered>().ImplementedBy<DefaultRegistration>());
            // I'm not doing the optional registration, I just want to 
            // demonstrate upgrading a additional configuration
                        
            var t = container.Resolve<IEventuallyRegistered>();
            t.test();
        }
    }
