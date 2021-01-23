      private void NotifyPropertyChanged(
                                          [System.Runtime.CompilerServices.CallerMemberName]
                                          string   Property = null) 
    {  
       PropertyChanged(this, new PropertyChangedEventArgs(Property));        
    }
