        private void RegisterBtn2_Click(object sender, EventArgs e)
        {
            // check for valid input first
            if (string.IsNullOrWhiteSpace(NTB.Text) && string.IsNullOrWhiteSpace(ATB.Text) && string.IsNullOrWhiteSpace(RegUserNameTB.Text) && string.IsNullOrWhiteSpace(RegPasswordTB.Text))
            {
                MessageBox.Show("Please enter the following:" + "\n" + "Name" + "\n" + "Age" + "\n" + "\n" + "UserName" + "\n" + "Password");
            }
            else
            {
                User user = new User(RegUserNameTB.Text, RegPasswordTB.Text, NTB.Text, ATB.Text);
                User.AddUserToList(user);
            }
            Close();
        }
