    class ViewModel_Countries
    {
        private ObservableCollection<Models.Country> Countries;
        public ObservableCollection<Models.Country> PropertyCountries
        {
                set { SetProperty(ref Countries, value); }
                get { return Countries; }
        }
    
        private ICommand countryItemClickCommand;
        public ICommand CountryItemClickCommand;
        {
            get
            {
                return countryItemClickCommand ?? (countryItemClickCommand = new Command (async () => await ExecuteCountryClickCommand()));
            }
        }
    
    private async Task ExecuteCountryClickCommand()
    {
        App.MyNavigation.PushAsync(MyNewPage, true);
    }
}
