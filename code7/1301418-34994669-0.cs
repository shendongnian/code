       `[NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this,
                        new PropertyChangedEventArgs(propertyName));
            }
        }`
