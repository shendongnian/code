    private void ShowRegisterWindow(...)
    {
       frmRegister register = new frmRegister();
       DialogResult result = register.ShowDialog();      
       if(result == DialogResult.OK)
       {
          tbUsername.Text = register.Username;
       }
    }
