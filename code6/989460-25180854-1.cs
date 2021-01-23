    private void btnConfirm_Click(object sender, EventArgs e)
    {
        Profile pf = new Profile();
        if (txtFirstName.Text.Trim() == String.Empty)
        {
            errorProvider1.SetError(txtFirstName, "Your First Name is important.");
            return; 
        }
        else
        {
            errorProvider1.Clear();
            pf.FirstName = txtFirstName.Text;
        }
        .......
        // Pass your Profile class instance to the constructor of the frmProfile
        frmProfile profile = new frmProfile(pf);
        profile.Show();
        this.Hide();
    }
