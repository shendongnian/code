     foreach (var userId in yourListOfUserIds)
     {
        var userSetting = new UserSettings()
        {
           SystemUserId = userId, 
           IsSendAsAllowed = true //set the flag to true
        };
        organizationService.Update(userSetting);
     }
