     public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            Names = new List<Name>() { new Name { Description = "Name1", IsChecked = false }, new Name { Description = "Name2", IsChecked = false } };
        }
        
        private List<Name> _names;
        public List<Name> Names
        {
            get { return _names; }
            set
            {
                _names = value;
                RaisePropertyChanged(() => Names);
            }
        }
        
    }
