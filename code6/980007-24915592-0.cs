    private MvxCommand _signinCommand;
    public ICommand SigninCommand
    {
        get
        {
            _signinCommand = _signinCommand ?? new MvxCommand(DoSignin);
            return _signinCommand;
        }
    }
    private async void DoSignin()
    {
        try
        {
            if (!Validate())
            {
                return;
            }
            IsBusy = true;
            var success = await SigninService.SigninAsync(Email, Password);
            if (success)
            {
                Result = "";
                ShowViewModel<HomeViewModel>();
                Close();
                return;
            }
            Result = "Invalid email/password. Please try again.";
        }
        catch (Exception ex)
        {
            Result = "Error occured during sign in.";
            Mvx.Error(ex.ToString());
        }
        finally
        {
            IsBusy = false;
        }
    }
