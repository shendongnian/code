    public class Authenticate
    {
      private string _password;
      private string _username;
    
      public Authenticate()
      {
        _password = "mypassword";
        _username = "myusername";
      }
    
      public string Password
      {
        get { return _password; }
        set
        {
          if (_password != value)  // Compare it here
            _password = value;
        }
      }
    
      public string Username
      {
        get { return _username; }
        set
        {
          if (_username != value)  // Compare it here
            _username = value;
        }
      }
    }
