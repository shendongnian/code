    string oldPassword = txtOldPassword.Text.Trim();
    string newPassword = txtNewPassword.Text.Trim();
    string confirmPassword = txtConfirmPassword.Text.Trim();
    
    if (newPassword == oldPassword)
    {
      //Sorry you can't have this as its the same
    }
    else if (confirmPassword != newPassword)
    {
      //Sorry your new password doesn't match the confirmation 
    }
    else
    {
      //All good to go
    }
