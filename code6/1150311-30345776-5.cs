    public class MyListItem : ImplementPropertyChangedStuff
    {
        private string _myString;
        private bool _myBool;
        public MyListItem()
        { }
        public string MyStringProperty
        {
            get { return _myString; }
            set
            {
                _myString = value;
                this.RaisePropertyChanged("MyStringProperty");
            }
        }
        public bool MyBoolProperty
        {
            get { return _myBool; }
            set
            {
                _myBool = value;
                this.RaisePropertyChanged("MyBoolProperty");
            }
        }
    }
