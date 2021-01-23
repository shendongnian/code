	public class GameViewModel : ViewModelBase
    {
		private INavigationService _navigationService;
		public GameViewModel(INavigationService NavigationService)
		{
			_navigationService = NavigationService;
		}
		// Then, when you want to expose a navigation command:
		_navigationService.NavigateTo("MainPage");
		private RelayCommand NavigateToMenuCommand
		public RelayCommand OkCommand
		{
			get
			{
				return _navigateToMenuCommand
					?? (_navigateToMenuCommand = new RelayCommand(
					() =>
					{
						_navigationService.NavigateTo("MainPage");
					}
			{
		}
	}
	
