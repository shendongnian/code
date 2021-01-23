     public class Sample
    {
        public string Name { set; get; }
        public string Location { set; get; }
    }
      private ObservableCollection<Sample> _items=new ObservableCollection<Sample>()
        {
            new Sample()
            {
                Location = "Loc1",
                Name = "Nam1"
            }
        }; 
        public ObservableCollection<Sample> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }
