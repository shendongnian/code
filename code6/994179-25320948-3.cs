    public void UpdateList() {
        userClass.AccountUpdate(id, txtUsername.Text, txtPassword.Text, txtPosition.Text);
        MessageBox.Show("Account updated!");
        ViewList();
    }
 
