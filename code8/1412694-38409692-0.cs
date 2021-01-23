    // Adapter will give you an interface
    // to either your local store
    // or your online store
    private IDataAdapter Adapter 
    {
       get 
       {
           IDataAdapter _adapter = null;
           CheckServer();
           if (Program.IsOnline) 
           {
                _adapter = CreateOnlineAdapter();
           }
           else
           {
                _adapter = CreateOfflineAdapter(); 
           }
           return _adapter
       }   
    } 
