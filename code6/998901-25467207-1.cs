    public class ModelBase
    {
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class SomeItem : ModelBase
    {
        private string name;
        private string imagePath;
        public String Name
        {
            get { return name; }
            set
            {
                if (value == name) return;
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public String ImagePath
        {
            get { return imagePath; }
            set
            {
                if (value == imagePath) return;
                imagePath = value;
                OnPropertyChanged("ImagePath");
            }
        }
    }
