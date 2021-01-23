    switch (userId)
                    {
                        case -1:
                            Login1.FailureText = "Username and/or password is incorrect.";
                            break;
                        case -2:
                            Login1.FailureText = "Account has not been activated.";
                            break;
                        default:
    Session["UserName"]=Login1.UserName; Session["RememberMeSet"]=Login1.RememberMeSet;
                           
    FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);
                            break;
                    }
