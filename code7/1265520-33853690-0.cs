    private static flag = true;
    private void logIn(object sender, RoutedEventArgs e)
        {
            if(flag){
            flag=false;
            string nameRecord = "";
            string passRecord = "";
            if (UsernameField.Text == "" || UserPassField.Password == "")
            {
                openErrorMarquee("Username and password required");
            }
            else
            {
                using (otongadgethubEntities logCheck = new otongadgethubEntities())
                {
                    var userNullCheck = logCheck.users.FirstOrDefault(a => a.username == UsernameField.Text);
                    if (userNullCheck == null)
                    {
                        openErrorMarquee("Username does not exist");
                    }
                    if (userNullCheck != null)
                    {
                        nameRecord = userNullCheck.username;
                    }
                    if (nameRecord == UsernameField.Text)
                    {
                        passRecord = Encrypt.MD5(UserPassField.Password).ToLower();
                        if (passRecord == userNullCheck.password)
                        {
                            //Yay! User logged in!
                        }
                        else
                        {
                            openErrorMarquee("Password invalid");
                        }
                    }
                }
            }
          }
          else
          {
          openErrorMarquee("you pressed more one time");
           }
         }
