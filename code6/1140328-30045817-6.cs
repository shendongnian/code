      private long? _id;
            public long? Id
            {
                get
                {
                    return _id;
                }
                set
                {
                    if (value != _id)
                    {
                        _id = value;
                        NotifyPropertyChanged("Id");
                    }
                }
            }  
