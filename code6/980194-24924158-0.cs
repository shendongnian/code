    container.Register(Component.For<ILazyComponentLoader>()
                                .ImplementedBy<LazyOfTComponentLoader>());
    public class CompositeModule : ICompositeModule
    {
        private IEnumerable<IModule> _childModules;
        public CompositeModule(IEnumerable<IModule> childModules) 
        {
            _childModules = childModules;
        }
    }
    
    public class CheckChildrenModule : IModule
    {
        private Lazy<ICompositeModule> _compositeModule;
        public CheckChildrenModule(Lazy<ICompositeModule> compositeModule)
        {
            _compositeModule = compositeModule;
        }
        public void DoStuff() 
        {
            _compositeModule.Value.DoStuff();
        }
    }
