      public class YourWinformCommand: ICommand
        {
            private User _user;
            private Guid _securityCode = new Guid(".......");
    
            public Guid GetUniqueId()
            {
                return _securityCode;
            }
    
            public  bool Execute()
            {
    
                if (_user.HasAccessTo(_securityCode))
                {
                    //Load the winform here.
    
                    return true
                }
    
                 return false;
            }
        }
