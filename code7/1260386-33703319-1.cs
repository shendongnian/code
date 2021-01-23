    class MainWindowViewModel : INotifyPropertyChanged, INotifyPropertyChanging
    {
        private string textBlockValue;
        public string TextBlockValue
        {
            set
            {
                if (textBlockValue != value)
                {
                    OnPropertyChanging("TextBlockValue");
                    textBlockValue = value;
                    OnPropertyChanged("TextBlockValue");
                }
            }
            get
            {
                return textBlockValue;
            }
        }
        ///////////////////////////////////////////////////////
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region INotifyPropertyChanging Members
        public event PropertyChangingEventHandler PropertyChanging;
        #endregion
        public void OnPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
                PropertyChanging.Invoke(this, new PropertyChangingEventArgs(propertyName));
        }
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
