    public enum MyType
        {
            First,
            Second
        }
    
        public interface IImplementMe
        {
            MyType TypeOfClass { get; }
            void DoSomething();
        }
        public class FirstImplementation : IImplementMe
        {
            public void DoSomething()
            {
                Console.WriteLine("First");
            }
    
            public MyType TypeOfClass
            {
                get
                {
                    return MyType.First;
                }
            }
        }
        public class SecondImplementation : IImplementMe
        {
            public void DoSomething()
            {
                Console.WriteLine("Second");
            }
    
            public MyType TypeOfClass
            {
                get
                {
                    return MyType.Second;
                }
            }
        }
    
    
        public interface IService { }
        public class Service : IService
        {
            private bool someCondition = true;
    
            private IImplementMe first;
            private IImplementMe second;
            IEnumerable<IImplementMe> hebele;
    
            public Service(IEnumerable<IImplementMe> hebele)
            {
                this.hebele = hebele;
                foreach (var item in hebele)
                {
                    switch (item.TypeOfClass)
                    {
                        case MyType.First:
                            first = item;
                            break;
                        case MyType.Second:
                            second = item;
                            break;
                        default:
                            break;
                    }
                }
            }
    
    
            public void Foo()
            {
                if (someCondition)
                {
                    first.DoSomething();
                }
                else
                {
                    second.DoSomething();
                }
            }
        }
   
    class Program
        {
            static void Main(string[] args)
            {
                IUnityContainer myContainer = new UnityContainer();
    
    
                myContainer.RegisterType<IImplementMe, FirstImplementation>("First");
                myContainer.RegisterType<IImplementMe, SecondImplementation>("Second");
                myContainer.RegisterType<IEnumerable<IImplementMe>, IImplementMe[]>();
    
    
                myContainer.RegisterType<IService, Service>();
    
    
                var srv = myContainer.Resolve<Service>();
                srv.Foo();
            }
        }
