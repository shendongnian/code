    private MvxCommand _signIn;
    public MvxCommand SignIn
    {
        get
        {
            return _signIn ?? (_signIn = new MvxCommand(() =>
            {
                client.AuthorizeCompleted += ((sender, args) =>
                {
                    try
                    {
                        if (args.Result)
                        {
                            //Success.. Carry on
                        }
                    }
                    catch (Exception ex)
                    {
                        //AccessDenied Exception thrown by service
                        if (ex.InnerException != null && string.Equals(ex.InnerException.Message, "Access is denied.", StringComparison.CurrentCultureIgnoreCase))
                        {
                            //Display Message.. Incorrect Credentials
                        }
                        else
                        {
                            //Other error... Service down?
                        }
                    }
                });
                client.AuthorizeAsync(UserName, Password, null); 
            }));
        }
    }
