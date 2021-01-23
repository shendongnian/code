    class Document : INotifyPropertyChanged
    {
        private bool isDirty;
        public bool IsDirty
        {
            get { return isDirty; }
            set
            {
                isDirty = value;
                OnPropertyChanged();
                OnPropertyChanged("DecoratedTitle");
            }
        }
        private String title;
        public String Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }
        public String DecoratedTitle
        {
            get { return title + (isDirty ? " (*)" : ""); }
        }
        private void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
