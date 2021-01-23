     public event PropertyChangedEventHandler PropertyChanged;
     private void OnPropertyChanged(string property)
     {
         if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(property));
     }
