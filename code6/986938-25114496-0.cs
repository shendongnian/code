    public class ActiveProject : INotifyPropertyChanged
    {
        private string name;
        public String Name
        {
            get { return name; }
            set
            {
                if (value == name) return;
                name = value;
                OnPropertyChanged(); // Signals the UI that the property value has changed, and forces a re-evaluation of all bindings for this property
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator] // No R#? Shame on you and comment this line out
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }        
    }
