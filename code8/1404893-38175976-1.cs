    await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => 
    {
         //write your code
         //in OnPropertyChanged use PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    });
