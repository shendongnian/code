    public partial class FrmAdminPassword : Form
    {
        private void btnLoginAdmin_Click(object sender, EventArgs e)
        {
            if (mskAdminPassword.Text == "password")
                this.DialogResult  = DialogResult.OK;
            else
            {
                MessageBox.Show("Not a valid password");
                this.DialogResult = DialogResult.None;
            }
        }
    }
