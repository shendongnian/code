    public class Singleton : DependencyObject, INotifyPropertyChanged
    {
        private static Singleton _Instance;
        public static Singleton Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new Singleton();
                return _Instance;
            }
        }
        
        //Dependency Property    
        public static readonly DependencyProperty PropertyA = DependencyProperty.Register("A", typeof(string), typeof(Singleton));
        public string A
        {
            get { return GetValue(PropertyA).ToString(); }
            set { SetValue(PropertyA, value); }
        }
        //Property
        private int _B;
        public int B
        {
            get { return _B; }
            set
            {
                _B = value;
                RaisePropertyChanged("B");
            }
        }
    
        static Singleton()
        {
            Instance = new Singleton();
        }
        //INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new new PropertyChangedEventArgs(propertyName));
        }
    }
