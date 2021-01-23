        private void btnLoginAdmin_Click(object sender, EventArgs e)
        {
            if (mskAdminPassword.Text == "password")
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Not a valid password");
                this.Close();
            }
         }
