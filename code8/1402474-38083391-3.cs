    namespace WpfApplication1
    {
        public class Context : INotifyPropertyChanged
        {
            private bool _point1Blue;
            private bool _point2Blue;
            private bool _point3Blue;
            private bool _point4Blue;
            private bool _point5Blue;
    
            public Context()
            {
                Point1Blue = true;
                Point2Blue = true;
                Point3Blue = false;
                Point4Blue = true;
                Point5Blue = false;
    
            }
    
            public bool Point1Blue
            {
                get { return _point1Blue; }
                set
                {
                    if (value == _point1Blue) return;
                    _point1Blue = value;
                    OnPropertyChanged("Point1Blue");
                }
            }
    
            public bool Point2Blue
            {
                get { return _point2Blue; }
                set
                {
                    if (value == _point2Blue) return;
                    _point2Blue = value;
                    OnPropertyChanged("Point2Blue");
                }
            }
    
            public bool Point3Blue
            {
                get { return _point3Blue; }
                set
                {
                    if (value == _point3Blue) return;
                    _point3Blue = value;
                    OnPropertyChanged("Point3Blue");
                }
            }
    
            public bool Point4Blue
            {
                get { return _point4Blue; }
                set
                {
                    if (value == _point4Blue) return;
                    _point4Blue = value;
                    OnPropertyChanged("Point4Blue");
                }
            }
    
            public bool Point5Blue
            {
                get { return _point5Blue; }
                set
                {
                    if (value == _point5Blue) return;
                    _point5Blue = value;
                    OnPropertyChanged("Point5Blue");
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged(string propertyName)
            {
                var handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
