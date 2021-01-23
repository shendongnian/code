    public static void CleanUpHome()
    {
        SimpleIoc.Default.Unregister<HomeViewModel>();
        SimpleIoc.Default.Register<IHomeViewModel, HomeViewModel>();
    }
