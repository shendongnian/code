    using System.ComponentModel;
    public class DemoItem : INotifyPropertyChanged
    {
        private int _age;
        private int _score;
        private string _name;
        public int Age
        {
            get { return _age; }
            set { if (_age != value) { _age = value; OnPropertyChanged("Age"); } }
        }
        public int Score
        {
            get { return _score; }
            set { if (_score != value) { _score = value; OnPropertyChanged("Score"); } }
        }
        public string Name
        {
            get { return _name; }
            set { if (_name != value) { _name = value; OnPropertyChanged("Name"); } }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
