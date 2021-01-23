	public class MenuPageViewModel : ViewModelBase
	{
		IViewFactory _viewFactory;
		public MenuPageViewModel (IViewFactory viewFactory)
		{
			_viewFactory = viewFactory;
			ShowDetail1Command = new Command (ShowDetail1);
			ShowDetail2Command = new Command (ShowDetail2);
		}
		public ICommand ShowDetail1Command { get; set;}
		public void ShowDetail1() {
			var mainPage = _viewFactory.Resolve<MainPageViewModel> ();
			((MasterDetailPage)mainPage).Detail = new NavigationPage (_viewFactory.Resolve<DetailViewModel1> ());
		}
		public ICommand ShowDetail2Command { get; set;}
		public void ShowDetail2() {
			var mainPage = _viewFactory.Resolve<MainPageViewModel> ();
			((MasterDetailPage)mainPage).Detail = new NavigationPage (_viewFactory.Resolve<DetailViewModel2> ());
		}
	}
