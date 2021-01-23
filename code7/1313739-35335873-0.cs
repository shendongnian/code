    public partial class loginForm : Form
    {
        // administratorForm administratorFormular = new administratorForm();
    
        public loginForm()
        {
            InitializeComponent();
        }
    
        private void loginButton_Click(object sender, EventArgs e)
        {
            if (usernameTextBox.Text == "administrator" && passwordTextBox.Text == "administrat0r")
            {
                var administratorFormular = new administratorForm();
                administratorFormular.loginFormular = this;
                administratorFormular.Show();
                this.Hide();
            }
            else if (usernameTextBox.Text == "player" && passwordTextBox.Text == "pl4yer")
            {
    
            }
            else
            {
                MessageBox.Show("Wrong username or password!");
                usernameTextBox.Text = "";
                passwordTextBox.Text = "";
            }
        }
    }
    public partial class administratorForm : Form
    {
        // loginForm loginFormular = new loginForm();
        public loginFormular LoginForm;
        public administratorForm()
        {
            InitializeComponent();
        }
    
        private void exitButton_Click(object sender, EventArgs e)
        {
            loginFormular.Close();
        }
    }
