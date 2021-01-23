    public class Person : INotifyPropertyChanged
    {
        //custom events as needed
        public event EventHandler NameChanged = delegate { };
        //needed for INotifyPropertyChanged 
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    this.NotifyPropertyChanged();
                    //Fire my custom event
                    this.NameChanged(this, EventArgs.Empty);
                }
            }
        }
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                if (_age != value)
                {
                    _age = value;
                    this.NotifyPropertyChanged();
                    //I am not exposing a custom event for this property.
                }
            }
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
