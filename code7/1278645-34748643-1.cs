       class personalSeance : INotifyPropertyChanged
    {
            public ObservableCollection<Ressource> listRess { get; set; }
       public event PropertyChangedEventHandler PropertyChanged;
        private void raiseOnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
