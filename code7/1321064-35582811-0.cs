    public class Data : INotifyPropertyChanged
    { 
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //C# 6 null-safe operator. No need to check for event listeners
            //If there are no listeners, this will be a noop
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
        // C# 5 - CallMemberName means we don't need to pass the property's name
        protected bool SetField<T>(ref T field, T value,
        [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        private string name;
        public string Name
        {
            get { return name; }
            //C# 5 no need to pass the property name anymore
            set { SetField(ref name, value); }
        }
    }
