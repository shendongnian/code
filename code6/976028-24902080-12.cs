    object  _messageControl; 
    public object MessageControl
               {
                   get { return _messageControl; }
                   set
                   {
                       if (_messageControl!= value)
                       {
                           _messageControl = value;
                           RaisePropertyChanged(() => MessageControl);
                       }
                   }
               }
