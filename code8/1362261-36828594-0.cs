            Application.Run(loginForm);
            if (loginForm.IsLoggedIn == true)
            {
                ERS_FDData.ERSUser user = loginForm.user;
                loginForm.Close();
                Application.Run(new frmMain(loginForm.user));
            }
            else
                Application.Exit();
