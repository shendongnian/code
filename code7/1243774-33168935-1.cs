    		protected override void ConfigureApplication(IContainer container)
			{
			
				// set main page
				var viewFactory = container.Resolve<IViewFactory>();
				var mainPage = viewFactory.Resolve<MainPageViewModel> ();
				_application.MainPage = mainPage;
			}
