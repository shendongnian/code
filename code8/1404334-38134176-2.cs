    object result = LoginVerify.ExecuteScalar();
    if (result == null)
        MessageBox.Show("Invalid username/password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
    else
    {
        GlobalVariables.UserLoggedIn = Convert.ToInt32(result);
        PWLists MainForm = new PWLists();
        MainForm.ShowDialog();
        this.Close();
    }
