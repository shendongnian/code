    public class WebUrl { }
    public class StockDelay { }
    public interface IModulePart<T> { }
    public class WebUrlModule : IModulePart<WebUrl> { }
    public class StockDelayModule : IModulePart<StockDelay> { }
    public interface IModulePartFactory
    {
        IModulePart<T> FindModulePartFor<T>();
    }
    
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = new Castle.Windsor.WindsorContainer();
            container.AddFacility<TypedFactoryFacility>();
            
            container.Register(
                Classes.FromAssemblyInThisApplication()
                    .BasedOn(typeof(IModulePart<>))
                    .WithService.Base()
                    .LifestyleTransient(),
                Component.For<IModulePartFactory>().AsFactory()
            );
            var factory = container.Resolve<IModulePartFactory>();
            var moduleForWebUrl = factory.FindModulePartFor<WebUrl>(); 
            // type is WebUrlModule
            var moduleForStockDelay = factory.FindModulePartFor<StockDelay>();
            // type is StockDelayModule
        }
    }
