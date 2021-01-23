	    public class MainPage : MasterDetailPage
	    {
		    public MainPage (INavigator navigator)
		    {
			    Master = navigator.ResolveView<MenuPageViewModel>();
			    Detail = new NavigationPage (navigator.ResolveView<DetailViewModel1>());
		    }
	    }
