       public class Ekta : Notifier
        {
            private string _PATHMED;
            public string PATHMED
            {
                get { return _PATHMED; }
                set
                {
                    _PATHMED = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("FULLPATH");
                }
            }
            private string _FICMED;
            public string FICMED
            {
                get { return _FICMED; }
                set
                {
                    _FICMED = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged("FULLPATH");
                }
            }
            public string FULLPATH
            {
                get { return PATHMED + FICMED; }
            }
        }
