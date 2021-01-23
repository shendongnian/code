    public class Person_UC_ViewModel
    {
        public Person_UC_ViewModel()
        {
            //Register your message
            Messenger.Default.Register<YourMessage>(message => ComboBoxIsEnabled = message.ComboBoxIsEnabled);
        }
        private bool _comboBoxIsEnabled;
        public bool ComboBoxIsEnabled
        {
            get 
            {
                return _comboBoxIsEnabled;
            }
            set
            {
                _comboBoxIsEnabled = value;
               OnPropertyChanged("ComboBoxIsEnabled");
            }
        } 
  
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
