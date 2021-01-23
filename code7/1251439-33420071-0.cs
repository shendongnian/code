        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
        }
