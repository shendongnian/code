    public string Title {
       get { return _title; }
       set {
             if (value != _title)
             {
                 _title = value;
                 IsModified = true;
             }
        }
    }
