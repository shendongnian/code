    public partial class WinExpander : Window
    {
        public WinExpander()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
        }
    } 
    public class ViewModel
        {
            public List<Country> Countries { get; set; }
            public ViewModel()
            {
                Countries = new List<Country>();
            }
        }
    
    public class Country
        {
            public string Name { get; set; }
            public List<League> Leagues { get; set; }
    
            public Country()
            {
                Leagues = new List<League>();
            }
        }
    
        public class League
        {
            public string Name { get; set; }
            public List<Match> Matches { get; set; }
    
            public League()
            {
                Matches = new List<Match>();
            }
        }
    
        public class Match
        {
            public string Name { get; set; }
        }
