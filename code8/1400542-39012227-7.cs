    public override INavigable ResolveForPage(Page page, NavigationService navigationService)
    {
        if (page is MainPage)
        {
            return SimpleIoc.Default.GetInstance<MainPageViewModel>();
            //(AppController.UnityContainer as UnityContainer).Resolve<INavigable>();
        }
        else
            return base.ResolveForPage(page, navigationService);
    }
