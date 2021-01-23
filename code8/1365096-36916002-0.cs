            private int _Zindex;
            public int Zindex
            {
                get { return _Zindex; }
                set
                {
                    if (_Zindex == value)
                    {
                        return;
                    }
                    _Zindex = value;
                    NotifyPropertyChanged("Zindex");
                }
            }
