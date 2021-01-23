    protected virtual void OnPropertyChanged(string propertyName)
    {
       uiSynchronizationContext.Post(
            () => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName))
           ,null
         );
    }
