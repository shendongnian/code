     public Task CheckPassword()
     {
         return Task.Run(() =>
         {
            // Creates instance of password hash to compare plain text and encrypted passwords.
            PasswordHash hash = new PasswordHash();
            // Checks password with registered user password to confirm access to account.
            InvokeOnMainThread(() => {
                if (hash.ValidatePassword(txtPassword.Text ,mCurrentUser.password)==true)
                {
                    Console.WriteLine("Password correct");
                    UIAlertView alert = new UIAlertView()
                    {
                        Title = "Login Alert",
                        Message = "Password Correct Loggin In"
                    };
                    alert.AddButton("OK");
                    alert.Show();
                    //insert intent call to successful login here.
                }
                else
                {
                    UIAlertView alert = new UIAlertView()
                    {
                        Title = "Login Alert",
                        Message = "Incorrect email or password entered"
                    };
                    alert.AddButton("OK");
                    alert.Show();
                }
            });
            Console.WriteLine("Finished check password");
        });
    }
