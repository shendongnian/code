    public class UnityViewModel : ViewModelBase
    {
        public string HelloMessage { get; }
        [Dependency]
        public IDataService DataService { get; set; }
        private IEnumerable<Person> people;
        public IEnumerable<Person> People
        {
            get { return people; }
            set { this.Set(ref people, value); }
        }
        public UnityViewModel()
        {
            HelloMessage = "Hello !";
        }
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode,
            IDictionary<string, object> suspensionState)
        {
            await Task.CompletedTask;
            People = DataService.GetPeople();
        }
    }
