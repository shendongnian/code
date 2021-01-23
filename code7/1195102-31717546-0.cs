    public abstract class ViewModelBase : INotifyPropertyChanged, IMVVMDockingProperties
        { 
    protected void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
    
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
    }
