	static ViewModelLocator()
	{
		ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
		var nav = new NavigationService();
		nav.Configure("MainMenu", typeof(MainMenuView));
		nav.Configure("About", typeof(AboutView));
		nav.Configure("Game", typeof(GameView));
		SimpleIoc.Default.Register<INavigationService>(() => nav);
		SimpleIoc.Default.Register<MainMenuViewModel>();
		SimpleIoc.Default.Register<AboutViewModel>();
		SimpleIoc.Default.Register<GameViewModel>();
	}
	
