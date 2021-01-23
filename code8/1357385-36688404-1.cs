    protected virtual void OnPropertyChanged(string propertyName)
    {
       uiSynchronizationContext.Post(
            o => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName))
           ,null
         );
    }
