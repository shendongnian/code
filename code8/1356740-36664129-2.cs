    class Test : INotifyPropertyChanged
    {
        private string name = "";
    
        public string Name
        {
            get { return name; }
            set { name = value; NotifyPropertyChanged(); }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void NotifyPropertyChanged()
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Name"));
            }
        }
    }
