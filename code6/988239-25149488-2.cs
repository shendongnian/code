    public class Person : ViewModel
    {
        public string Header { get; set; }
        private bool _isSelected;
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                this.NotifyPropertyChanged("IsSelected");
            }
        }
        public Person(string n)
        {
            Header = n;
        }
    }
