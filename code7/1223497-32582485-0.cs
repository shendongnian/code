        public interface IFoo
        {
            void Operation();
        }
        public class Foo : IFoo
        {
            [OptionalDependency]
            public Bar Bar { get; set; }
            public void Operation()
            {
                if (Bar == null)
                    Console.Write("Bar is null..");
                else
                    Console.Write("Bar isn't null!");
            }
        }
        (...)
        container.RegisterType<IFoo, Foo>(); //container is an IUnityContainer
        var fooInstance = container.Resolve<IFoo>();
        fooInstance.Operation();
