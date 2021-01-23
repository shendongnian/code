    public ModuleItems(IUnityContainer container)
    {
        _container = container;
    }
    public void Initialize()
    {
        _container.RegisterType<object, ToolBarView>(typeof(ToolBarView).FullName);
        _container.RegisterType<object, DockingView>(typeof(DockingView).FullName);
        // rest of initialisation
    }
