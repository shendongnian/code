        var user = manager.FindByName(Email.Text);
        if (user != null)
        {
            if (!user.EmailConfirmed)
            {
                FailureText.Text = "Invalid login attempt. You must have a confirmed email address. Enter your email and password, then press 'Resend Confirmation'.";
                ErrorMessage.Visible = true;
                ResendConfirm.Visible = true;
            }
            else
            {
                 // your other logic goes here if the user is confirmed.
                 ....
            }
        }
        else 
        {
            // user does not exist.
        }
