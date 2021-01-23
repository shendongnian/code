	    public class MainPage : MasterDetailPage
	    {
		    public MainPage (IViewFactory viewfactory)
		    {
			    Master = viewfactory.Resolve<MenuPageViewModel>();
			    Detail = new NavigationPage (viewfactory.Resolve<DetailViewModel1>());
		    }
	    }
