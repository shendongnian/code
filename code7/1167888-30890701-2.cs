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
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
   
