    class MyViewModel : INotifyPropertyChanged
    {
        private string m_serachType;
        public string SearchType
        {
            get { return m_serachType; }
            set
            {
                m_serachType = value;
                OnPropertyChanged("SearchType");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
