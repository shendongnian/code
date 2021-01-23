    public class MyViewModel : ViewModelBase
    {
        public ICommand NavigateCommand { get; private set; }
        public MyViewModel()
        {
            NavigateCommand = new DelegateCommand<string>(url => {
                var uri = new Uri(url, UriKind.Relative);
                NavigationService.Navigate(uri);
            });
        }
    }
