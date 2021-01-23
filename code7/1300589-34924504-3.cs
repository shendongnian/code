    private void btnSubmit_Click(object sender, EventArgs e)
        {
            UserAdmin admin = new UserAdmin();
            UserEmployee empp = new UserEmployee();
            bool validateAdmin = admin.Validate(txtUsername.Text, txtPassword.Text);
            bool validateEmpp = empp.Validate(txtUsername.Text, txtPassword.Text);
            if (validateAdmin)
            {
                MessageBox.Show("Successfylly login as Admin");
                //operation here 
            }
            else if (validateEmpp)
            {
                MessageBox.Show("Successfylly login as " + txtUsername.Text);
                //operation here 
            }
            else { MessageBox.Show("Incorrect password or username"); }
        }
