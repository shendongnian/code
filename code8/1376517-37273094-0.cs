    public Ilist<string> ActionType
    {
       get { return _actionType; }
       set
       {
          _actionType= value;
          OnPropertyChanged("ActionType");
       }
    }
