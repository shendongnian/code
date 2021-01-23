    public partial class LoginForm : Form
    {
        public int MyEnumCode = 0;
        public LoginForm()
        {
            InitializeComponent();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (textUser.Text == "administrator" && textPass.Text == "administrat0r")
            {
                MyEnumCode = 1;
                this.DialogResult = DialogResult.OK;
            }
            else if (textUser.Text == "player" && textPass.Text == "pl4yer")
            {
                MyEnumCode = 2;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Wrong username or password!");
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
