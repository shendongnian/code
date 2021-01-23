    private void adminToolStripMenuItem_Click(object sender, EventArgs e)
    {
        // Putting the creation of the form inside a using block allows
        // the automatic closing and disposing of the form when the code
        // reaches the closing brace of the using block.
        using(FrmAdminPassword frmAdminPassword = new FrmAdminPassword())
        {
            // This opens the frmAdminPassword form in modal mode, no 
            // code is executed after the call until you close the 
            // form with DialogResult.OK, DialogResult.Cancel or whatever 
            if(DialogResult.OK == frmAdminPassword.ShowDialog())
            {
                MessageBox.Show("Login executed with success!");
            }
            else
            {
                // Mo password given or form cancelled
                // put here the logic to exit or disable things
            }
        }
    }
