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
    container.RegisterSingle<AbstractBase>(new LazyAbstractBaseProxy(
        new Lazy<AbstractBase>(() => (AbstractBase)container.GetInstance(type)));
        
