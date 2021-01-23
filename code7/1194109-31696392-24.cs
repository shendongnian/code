    public class LazyAbstractBaseProxy : AbstractBase
    {
        private readonly Lazy<AbstractBase> lazy;
        public LazyAbstractBaseProxy(Lazy<AbstractBase> lazy) {
            this.lazy = lazy;
        }
        
        public override void SomeFunction() {
            this.lazy.Value.SomeFunction();
        }
    }
    
    Type type = GetConfiguredAbstractBaseType();
    var lazy = new Lazy<InstanceProducer>(() =>
        Lifestyle.Singleton.CreateProducer(typeof(AbstractBase), type, container));
    container.RegisterSingle<AbstractBase>(new LazyAbstractBaseProxy(
        new Lazy<AbstractBase>(() => (AbstractBase)lazy.Value.GetInstance()));
        
