    public List<string> DBNameList
            {
                get { return _DBNameList; }
                set
                {
                    if(_DBNameList != value)
                    {
                        _DBNameList = value;
                        RaisePropertyChanged("DBNameList");
                    }
                }
            }
