    private void btnRegistration_Click_1(object sender, EventArgs e)
    {
                   if (txtRegPassConfirm.Text != txtRegPass.Text)
                    {
                        MessageBox.Show("Passwords do not match");
                        txtRegPassConfirm.Clear();
                        return;
                    }
                    else
                    {
                        if (txtRegPass.Text.Length < 8)
                        {
                            MessageBox.Show("Password must be at least 8 characters long");
                            txtRegPassConfirm.Clear();
                            return;
                        }
                      
                    } 
          //put your next code as it is which you wrote in this click event
    }
