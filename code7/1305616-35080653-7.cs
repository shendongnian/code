    public class MainWindowVM
    {
        public MainWindowVM()
        {
            LoadData();
        }
        private void LoadData()
        {
            Persons = new ObservableCollection<Person>() {
            new Person() { IdPerson = 1, Name = "Billy" },
            new Person() { IdPerson = 2, Name = "Bobby" },
            new Person() { IdPerson = 2, Name = "Bond" } };
            Teams = new ObservableCollection<Team>() {
            new Team() { IdTeam = 1, NameTeam = "Team A" },
            new Team() { IdTeam = 2, NameTeam = "Team B" },
            new Team() { IdTeam = 3, NameTeam = "Team C" } };
        }
        
        public ObservableCollection<Person> Persons { get; set; }
        public ObservableCollection<Team> Teams { get; set; }
    }
