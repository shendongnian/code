    public class Team
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Matches { get; set; }
    }
      private ObservableCollection<Team> _teams=new ObservableCollection<Team>()
        {
            new Team()
            {
                Id="1",
                Matches = "45",
                Name = "TeamA"
            },
            new Team()
            {
                Id="1",
                Matches = "45",
                Name = "TeamB"
            },
            new Team()
            {
                Id="1",
                Matches = "45",
                Name = "TeamC"
            }
        };
        
     
        public ObservableCollection<Team> Teams
        {
            get
            {
                return _teams;
            }
            set
            {
                if (_teams == value)
                {
                    return;
                }
                _teams = value;
                OnPropertyChanged();
            }
        }
        
 
 
