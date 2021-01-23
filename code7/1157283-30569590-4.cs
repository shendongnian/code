    public class TelnetConnection
    {
      public string Login(string Username, 
                          string Password, int LoginTimeOutMs, ref string retVal)
      {
            //omitted
            retVal += Read();
            WriteLine(Password);
            retVal  += Read();
            TimeOutMs = oldTimeOutMs;
            return retVal ;
        }
     }
