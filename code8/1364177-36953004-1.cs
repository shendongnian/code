    public class HaveLoginData : BaseViewModel, IHaveLoginData
    {
         private string _login; 
         public string Login 
         {
              get { return _login; }
              set 
              {
                  _login = value;
                  OnPropertyChanged("Login");
              }
         } 
         private string _md5password; 
         public string MD5Password 
         {
              get { return _md5password; }
              set 
              {
                  _md5password = value;
                  OnPropertyChanged("MD5Password");
              }
         } 
    }
