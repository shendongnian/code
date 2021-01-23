    public class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<string> _schools;
        private string _selectedSchool;
    
        public ObservableCollection<string> Schools
        {
            get { return _schools; }
            set
            {                
                _schools = new ObservableCollection<string>(value);
                NotifyPropertyChange("Schools");
            }
        }
    
        public string SelectedSchool
        {
            get { return _selectedSchool; }
            set
            {
                if (_selectedSchool == value)
                    return;
    
                _selectedSchool = value;
                NotifyPropertyChange("SelectedSchool");
            }
        }
    }
