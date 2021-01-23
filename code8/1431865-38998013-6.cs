    public partial class LoginV : MetroWindow
    {
        public LoginV()
        {
            InitializeComponent();
    
            LoginVM _loginVM = new LoginVM();
            this.DataContext = _loginVM;
            _loginVM.PasswordSet += new EventHandler<string> (_loginVM_PasswordSet);
            
            UpdatePassword();
        }
        
        protected void UpdatePassword()
        {
            passwordBox.Password = e;
        }
    
        private void _loginVM_PasswordSet(object sender, string e)
        {
            UpdatePassword();
        }
