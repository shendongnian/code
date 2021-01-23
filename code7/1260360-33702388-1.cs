    private void submitBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(firstNameTxt.Text) || string.IsNullOrEmpty(lastNameTxt.Text)
               || string.IsNullOrEmpty(userNameTxt.Text) ||
               string.IsNullOrEmpty(passwordTxt.Text) || string.IsNullOrEmpty(confPassTxt.Text)
               || string.IsNullOrEmpty(majorBox.Text) || string.IsNullOrEmpty(specialtyBox.Text))
            {
                MessageBox.Show("You must enter in all fields before moving forward");
             
            } else {
                userObj = new User();
            }
    }
