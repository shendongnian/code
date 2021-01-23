    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> _locations;
        public ObservableCollection<string> Locations
        {
            get { return _locations; }
            set
            {
                _locations = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Locations"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public MainViewModel()
        {
            // Load our locations from the database here
            // You can instead populate yours from SQL
            Locations = new ObservableCollection<string>();
            Locations.Add("Location 1");
            Locations.Add("Location 2");
            Locations.Add("Location 3");
            Locations.Add("Location 4");
            // Now your combobox should be populated
        }
    }
