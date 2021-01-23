    bool userIsPermitted = GetUserPermission(currentuser);
    InitializeControls(userIsPermitted);
    
    ...
    
    InitializeControls(bool isAllowedToUseControls)
    {
       button1.Visibility = isAllowedToUseControls;
       button1.Enabled = isAllowedToUseControls;
    }
