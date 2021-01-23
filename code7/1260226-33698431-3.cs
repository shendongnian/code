    public class Model : INotifyPropertyChanged
    {
        private readonly RelayCommand _removeMe;
        private string _original;
        private string _encoded;
        private readonly IStructureManager _manager;
        public string Original
        {
            get
            {
                return _original;
            }
            set
            {
                _original = value;
                Encoded = ReverseString(_original);
                NotifyPropertyChanged();
            }
        }
        public string Encoded
        {
            get
            {
                return _encoded;
            }
            set
            {
                _encoded = value;
                NotifyPropertyChanged();
            }
        }
        public ICommand RemoveMeCommand
        {
            get
            {
                return _removeMe;
            }
        }
        public Model(IStructureManager manager, string original)
        {
            Original = original;
            _manager = manager;
            _removeMe = new RelayCommand(param => RemoveMe(), param => CanRemoveMe);
        }
        private void RemoveMe()
        {
            _manager.RemoveItem(this);
        }
        private bool CanRemoveMe
        {
            get
            {
                //Logic to enable/disable button
                return true;
            }
        }
        private string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
