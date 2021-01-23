    protected override void RegisterTypes()
    { 
        unityContainer.RegisterType<object, ItemControl>("ModuleAUpper");
        unityContainer.RegisterType<IViewModelItemControl, ViewModelItemControl>();
        unityContainer.RegisterTypeForNavigation<ItemControl>();
    }
