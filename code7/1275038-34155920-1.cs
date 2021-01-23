    public partial class Login : MetroWindow
    {
        public Login()
        {
            InitializeComponent();
        }
    
        private async void button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            await DoLogin();
        }
    
        private async Task DoLogin()
        {
            String email = txtEMail.Text;
            String password = txtPassword.Password;
    
            if (String.IsNullOrWhiteSpace(email))
            {
                await Globals.Logger.outputMetroUserMessage(this, UserErrorMessageController.GetTitleByID(103), UserErrorMessageController.GetMessageByID(103));
            }
            else if (String.IsNullOrWhiteSpace(password))
            {
                await Globals.Logger.outputMetroUserMessage(this, UserErrorMessageController.GetTitleByID(104), UserErrorMessageController.GetMessageByID(104));
            }
            else
            {
                // ...
            }
        }
    }
