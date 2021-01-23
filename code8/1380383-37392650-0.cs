    public class SecurityMonitor
    {
        public string Username{get;set;}
        public string Password{get;set;}
        public event LoginEventHandler LoginRequired;
        public bool CheckSecurity()
        {
            if(Username==null)
            {
                LoginRequired?.Invoke(this,new LoginEventArg());
                //wait logic here
            }    
            return CheckAccess();
        }
        public void Logout()
        {
            Username= null;
            Password= null;
        }
    }
