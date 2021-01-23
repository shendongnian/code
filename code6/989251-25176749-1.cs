            string LoginID = Session["user"].ToString();
            string OldPassword = txtOldPassword.Text.Trim();
            string LoginPassword = txtNewPassword.Text.Trim();
            if (OldPassword != Session["password"].ToString())
            {
                String sc = "<Script>alert('Old Password does not match')</script>";
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Ad" + DateTime.Now, sc, false);
            }
            else if (string.Equals(OldPassword, LoginPassword)) //THIS LINE HERE
            {
                //Old password matches new password
            }
            else
            {
                LoginLogic _LoginLogic = new LoginLogic();
                _LoginLogic.ChangePassword(LoginID, LoginPassword);
                //Exit the current session
                Session.Abandon();
                String sc = "<Script>alert('You have successfully changed your password. Please login again.');location.href='default.aspx'</script>";
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "Ad" + DateTime.Now, sc, false);
            }
