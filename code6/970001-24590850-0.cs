    public delegate void PropertyChangedEventHandler(object sender, PropertyChangedEventArgs e);
    public class PropertyChangedEventArgs : EventArgs
    {
        public PropertyChangedEventArgs(string propertyName, dynamic oldValue, dynamic newValue)
        {
            this.PropertyName = propertyName;
            this.OldValue = oldValue;
            this.NewValue = newValue;
        }
        public virtual string PropertyName { get; private set; }
        public virtual dynamic OldValue { get; private set; }
        public virtual dynamic NewValue { get; private set; }
    }
    public class PropertyClass
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void Set<T>(string propertyName, ref T field, T value)
        {
            if (field.Equals(value))
                return;
            T oldValue = value;
            field = value;
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName, oldValue, value));
        }
        // Properties
        private string _name;
        private string _message;
        private bool _isMember;
        public string Name
        {
            get { return _name; }
            set { Set("Name", ref _name, value); }
        }
        public string Message
        {
            get { return _message; }
            set { Set("Message", ref _message, value); }
        }
        public bool IsMember
        {
            get { return _isMember; }
            set { Set("IsMember", ref _isMember, value); }
        }
    }
