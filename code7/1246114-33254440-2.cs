    public bool MyProperty
    {
       get{ return myProperty; }
       set
       {
          myProperty = value;
          OnPropertyChanged(Helper.GetPropertyName(() => MyProperty));
       }
    }
