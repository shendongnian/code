        private void LoginCheck(API.LoginResp resp, CustomAsyncStateContainer state)
        {
            try
            {
                //Process response
                if (resp.header.errorCode != APIErrorEnum.OK)
                {
                    //Login Failed - Show error if login failed
                    if (loginForm == null)
                        new LoginWindow(this).ShowDialog();
                    else
                    {
                        loginForm.Activate();
                        loginForm.loginButtonEnabled = true;
                        loginForm.PWpasswordBox.Password = null;
                    }
                }
                else
                {
                    if (loginForm != null)
                    {
                        loginForm.Close();
                        //Continue with Main App
                    }
                }
            }
            catch (Exception ex)
            {
		          //Log error
            }
        }
