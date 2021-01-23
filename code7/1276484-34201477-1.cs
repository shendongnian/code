    public ModuleItems(IUnityContainer container)
    {
        _container = container;
    }
    public void Initialize()
    {
        _container.RegisterType<object, ModuleItemsView>(typeof(ModuleItemsView).FullName);
        // rest of initialisation
    }
