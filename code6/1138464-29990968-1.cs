    public class MyModel : INotifyPropertyChanged
    {
        private string _myString;
        public string MyString
        {
            get
            {
                return _myString;
            }
            set
            {
                _myString = value;
                OnPropertyChanged("MyString");
            }
        }
    }
