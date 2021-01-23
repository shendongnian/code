    void Login()
    {
        var login = new LoginForm();
        if (login.ShowDialog() == DialogResult.OK)
        {
            var userName = login.UserName;
        }
    }
    
    public class LoginForm : Form
    {
        public string UserName { get; private set; }
        
        public void OnOKButton_Click(object sender, EventArgs e)
        {
            // validation...
            
            this.DialogResult = DialogResult.OK;
            this.UserName = UserNameTextBox.Text;
            
            this.Dispose();
        }
    }
