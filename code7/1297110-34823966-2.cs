    public interface ISimpleService
        {
            string Test();
        }
        public class SimpleService1 : ISimpleService
        {
            public string Test()
            {
                return "Hello World from SimpleService1";
            }
        }
    
        internal class Program
        {
            private static void Main(string[] args)
            {
                var builder = new ContainerBuilder();
                {
                    builder.RegisterType<SimpleService1>().Named<ISimpleService>("fff").As<ISimpleService>();
                }
    
                IContainer container = builder.Build();
    
                var services = container.Resolve<IEnumerable<ISimpleService>>();
    
                Console.WriteLine(services.Count()); // 1.
            }
        }
