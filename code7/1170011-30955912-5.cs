    public class Data : INotifyPropertyChanged
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
        private int _Length;
        public int Length
        {
            get { return _Length; }
            set
            {
                _Length = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Length"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
