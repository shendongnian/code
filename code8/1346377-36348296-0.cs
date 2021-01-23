    public class LoginViewModel : INotifyPropertyChanged
    {
      public string Username{get;set;}
      public string Password{get;set;}
    
      public bool CanLogin {
        get{
            return Username.Length > 0 && Password.Length > 0;
        }
      }
    }
