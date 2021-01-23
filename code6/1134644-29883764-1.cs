     public class MainPageViewModel : PropertyChangedBase
    {
        public string HubHeader
        {
            get { return "Second Hand Bookshop"; }
        }
        public SearchViewModel SearchViewModel { get; set; }
        public NewestOffersViewModel NewestOffersViewModel { get; set; }
        public AddOfferViewModel AddOfferViewModel { get; set; }
        public AccountViewModel AccountViewModel { get; set; }
        public MainPageViewModel()
        {
            SearchViewModel = new SearchViewModel();
            NewestOffersViewModel = new NewestOffersViewModel();
            AddOfferViewModel = new AddOfferViewModel();
            AccountViewModel = new AccountViewModel();
        }
