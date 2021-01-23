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
                _adapter = new SqlDataAdapter(selectcommand, onlineconnection);
           }
           else
           {
                _adapter = new  SqlCeDataAdapter(selectCommand, offlineConnection);
           }
           return _adapter
       }   
    } 
