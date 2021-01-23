    private void UpdateUserStatus()
    {
        // get current list of user and status
        var newStatus = GetCurrentStatus();
        User thisUser;
    
        // find the changed user and update
        foreach (User u in newStatus)
        {          
            thisUser = Users.FirstOrDefault(q => q.Id == u.Id);
            // ToDo: If null, there is a new user in the list: add them.
            if (thisUser != null && thisUser.Status != u.Status)
            { 
                thisUser.Status = u.Status;
                thisUser.StatusImage = StatusImgs[(int)u.Status];
            }
        }
    }
