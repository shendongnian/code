    public partial class frmPassword : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=WORKSTATION\SQLEXPRESS;Initial Catalog=TPSystem;Integrated Security=True");
    
        public frmPassword()
        {
            InitializeComponent();
        }
    
        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            string UserN = login.UName;
            string Pass;
            SqlCommand cmd = new SqlCommand("SELECT Login_Password FROM AdminLogin WHERE Login_Username = '"+UserN+"'", connection);
    
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                Pass = reader["Login_Password"].ToString();
    
                if (tbOldPassword.Text == Pass)
                    MessageBox.Show("Password matches");
                else
                    MessageBox.Show("Password wrong");
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Report", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }
    }
