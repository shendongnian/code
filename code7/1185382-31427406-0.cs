    public class User : INotifyPropertyChanged
    {
        // implementation of INotifyPropertyChanged
        string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }
        int _age;
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
                NotifyPropertyChanged("Age");
            }
        }
        string _selectedRule;
        public string SelectedRule
        {
            get
            {
                return _selectedRule;
            }
            set
            {
                _selectedRule = value;
                NotifyPropertyChanged("SelectedRule");
            }
        }
    }
