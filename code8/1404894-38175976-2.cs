    public abstract class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
       public event PropertyChangedEventHandler PropertyChanged;
 
       protected async void OnPropertyChanged([CallerMemberName] string propName = "")
       {
           await Window.Current.Dispatcher.RunAsync(CoreDispatcherPriority.High,
               () =>
               {
                   PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
               });
       }
    }
