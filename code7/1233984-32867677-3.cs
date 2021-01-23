    public abstract class BindableBase : INotifyPropertyChanged
    {
        // Some other members
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals((object) storage, (object) value))
                return false;
            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
    }
