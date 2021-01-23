    public class TelnetConnection
    {
      public string Login(string Username, string Password, int LoginTimeOutMs)
      {
            string retVal = "";
            int oldTimeOutMs = TimeOutMs;
            TimeOutMs = LoginTimeOutMs;
            WriteLine(Username);
            retVal += Read();
            WriteLine(Password);
            retVal  += Read();
            TimeOutMs = oldTimeOutMs;
            return retVal ;
        }
     }
