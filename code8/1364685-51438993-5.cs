    public void GoToProfile()
    {
       //Say, this.CurrentUser is UserProfile 
       //and UserDetailsViewModel implements IAcceptArguments<UserProfile>
       _navigator.To<UserDetailsViewModel>().WithArguments(this.CurrentUser).Go();
    }
