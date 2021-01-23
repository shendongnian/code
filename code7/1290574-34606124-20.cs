    public class Student_UC_ViewModel : INotifyPropertyChanged
    {
        public Student_UC_ViewModel()
        {
            //Register your message
            Messenger.Default.Register<ChangeComboBoxEnabilityMessage>(message => ComboBoxIsEnabled = message.ComboBoxIsEnabled);
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
