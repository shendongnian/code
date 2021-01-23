	public class GameViewModel : ViewModelBase
    {
		private INavigationService _navigationService;
		public GameViewModel(INavigationService NavigationService)
		{
			_navigationService = NavigationService;
		}
		// Then, when you want to expose a navigation command:
		private RelayCommand _navigateToMenuCommand;
		public RelayCommand NavigateToMenuCommand
		{
			get
			{
				return _navigateToMenuCommand
					?? (_navigateToMenuCommand = new RelayCommand(
					() =>
					{
						_navigationService.NavigateTo("MainMenu");
					}
			{
		}
	}
	
