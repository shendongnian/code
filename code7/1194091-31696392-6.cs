    // This factory should be part of your composition root, 
    // because it now depends on the container.
    public class MyFactory : IMyFactory
    {
        private readonly Container container;
        private readonly Dictionary<ProductType, Lazy<InstanceProducer>> producers;
        public MyFactory(Container container) {
            this.container = container;
            this.producers = new Dictionary<ProductType, Lazy<InstanceProducer>>
            {
                {ProductType.Type1, new Lazy<InstanceProducer>(this.CreateProducer<Derived1>)},
                {ProductType.Type2, new Lazy<InstanceProducer>(this.CreateProducer<Derived2>)},
                {ProductType.Type3, new Lazy<InstanceProducer>(this.CreateProducer<Derived3>)}
            };
        }
        public AbstractBase Create() {
            return (AbstractBase)this.producers[AppSettings.ProductType].GetInstance()
        }
        
        private InstanceProducer CreateProducer<T>() where T : AbstractBase {
            Lifestyle.Singleton.CreateProducer<AbstractBase, T>(this.container);
        }
    }
    
