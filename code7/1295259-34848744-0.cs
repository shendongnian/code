    protected override void RegisterTypes()
    {            
       Container.RegisterType<object, TheBottomControl>("ModuleItemsBottom");
       Container.RegisterType<IBottomViewModel, TheBottomControlViewModel>();
       Container.RegisterTypeForNavigation<TheBottomControl>();
       Container.RegisterType<object, TheUpperControl>("ModuleItemsUpper");
       Container.RegisterType<IUpperViewModel, TheUpperControlViewModel>();            
       Container.RegisterTypeForNavigation<TheUpperControl>();          
    }
