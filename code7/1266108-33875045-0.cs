    public partial class LoginForm : Form
    {    
      
        public LoginForm()
        {
            InitializeComponent();
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
        
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (EntitiesModel context = new EntitiesModel(Global.ConnectionString))
                USER user = _context.USERs.FirstOrDefault(
                    u => u.USERNAME == txtUsername.Text.Trim() && 
                         u.PASSWORD == txtPassword.Text.Trim());
                // after authentication show main menu etc
            }
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
        
        }
    }
