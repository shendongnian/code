     public class ComboViewModel:BaseObservableObject
    {
        private string _comboSelectedValue;
        public ComboViewModel()
        {
            ComboItems = new ObservableCollection<ComboItem>
            {
                new ComboItem {Name = "Bob", Id = "1"},
                new ComboItem {Name = "Joe", Id = "2"},
                new ComboItem {Name = "John", Id = "3"},
                new ComboItem {Name = "Roi", Id = "4"},
            };
        }
        public ObservableCollection<ComboItem> ComboItems { get; set; }
        public string ComboSelectedValue
        {
            get { return _comboSelectedValue; }
            set
            {
                _comboSelectedValue = value;
                OnPropertyChanged();
            }
        }
    }
