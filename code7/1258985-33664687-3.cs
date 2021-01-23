    public class LoginParams 
    {
      public string UserName { get; set; }
      public string Password { get; set; }
    }
    public void BrowserLogin(LoginParams aParams)
    {
      if (aParams.UserName == null)
        <use this._username>
      if (aParams.Password == null)
        <use this._password>
    ...
    }
    BrowserLogin(new LoginParams());
    BrowserLogin(new LoginParams() { UserName = username });
    BrowserLogin(new LoginParams() { UserName = username, Password = password });
