    public class Customer:BaseObservableObject
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<string> Friends { get; set; }
    }
