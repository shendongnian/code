    public class Person : INotifyPropertyChanged
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Name"));
            }
        }
        private int _Age;
        public int Age
        {
            get { return _Age; }
            set
            {
                _Age = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Age"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
