    public string Message
                       {
      get { 
        return _message; 
        }
        set
        {
         if (_message!= value)
         {
         _message = value;
            string[] str=value.Split('^');
            String1=str[0];
            String2=str[1];
           RaisePropertyChanged("Message");
           }
          }
        }
