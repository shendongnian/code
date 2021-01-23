    private void adminToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using(FrmAdminPassword frmAdminPassword = new FrmAdminPassword())
        {
            // This opens the frmAdminPassword form in modal mode, no 
            // code is executed after the call until you close the 
            // admin with DialogResult.OK, DialogResult.Cancel or whatever 
            if(DialogResult.OK == frmAdminPassword.ShowDialog())
            {
                MessageBox.Show("Login executed with success!");
                
            }
            else
            {
                // Mo password given or form cancelled
            }
        }
    }
