    public void UpdateList() {
        userClass.AccountUpdate(txtUsername.Text, txtPassword.Text, txtPosition.Text);
        MessageBox.Show("Account updated!");
        ViewList();
    }
 
