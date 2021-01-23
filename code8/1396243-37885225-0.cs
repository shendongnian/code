     foreach (var userId in yourListOfUserIds)
     {
        var userSetting = new UserSettings()
        {
           SystemUserId = userId, 
           IsSendAsAllowed = false //set the flag to false
        };
        organizationService.Update(userSetting);
     }
