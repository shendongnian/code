    if (ViewModelBase.IsInDesignModeStatic)
    {
        SimpleIoc.Default.Register<IHomeViewModel, DesignHomeViewModel>();
    }
    else
    {
        SimpleIoc.Default.Register<IHomeViewModel, HomeViewModel>();
    }
