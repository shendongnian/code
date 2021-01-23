    public int MyInt
    {
       get { ... }
       set 
       {
           _MyInt = value;
           
           //Notify property changed for the read-only property too.
           OnPropertyChanged();
           OnPropertyChanged("MyBool");
       }
    }
