    public class MenuPageViewModel : ViewModelBase
	{
		INavigator _navService;
		public MenuPageViewModel (INavigator navService)
		{
			_navService = navService;
			ShowDetail1Command = new Command (ShowDetail1);
			ShowDetail2Command = new Command (ShowDetail2);
		}
		public ICommand ShowDetail1Command { get; set;}
		public void ShowDetail1() {
			var mainPage = _navService.ResolveView<MainPageViewModel> ();
			((MasterDetailPage)mainPage).Detail = new NavigationPage (_navService.ResolveView<DetailViewModel1> ());
		}
		public ICommand ShowDetail2Command { get; set;}
		public void ShowDetail2() {
			var mainPage = _navService.ResolveView<MainPageViewModel> ();
			((MasterDetailPage)mainPage).Detail = new NavigationPage (_navService.ResolveView<DetailViewModel2> ());
		}
	}
