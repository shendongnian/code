    public class SecondPageViewModel: ViewModelBase
    {
      public string Title { get; set; }
     
      public SecondPageViewModel(INavigationService navigationService) : base(navigationService)
      {
        Title = "Second Page";
      }
    }
    public void GoToSecondPage()
    {
      navigationService.UriFor<SecondPageViewModel>().WithParam(l=>l.Title, "Navigated from MainViewModel").Navigate();
    }
