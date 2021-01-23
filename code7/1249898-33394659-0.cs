        UserProfileService uprofService = new UserProfileService();
    
        uprofService.Url = adminPortalUrl + "/_vti_bin/UserProfileService.asmx";
        uprofService.UseDefaultCredentials = false;
    
        Uri targetSite = new Uri(url);
        uprofService.CookieContainer = new CookieContainer();
    
        string authCookieValue = spCredentials.GetAuthenticationCookie();
    uprofService.CookieContainer.SetCookies(targetSite, authCookieValue);
    
        var userProfileResult = uprofService.GetUserProfileByIndex(-1);
    
       long numProfiles = uprofService.GetUserProfileCount(); 
    
       while (userProfileResult.NextValue != "-1")
       {
    
         string personalUrl = null;
    
         foreach(var  u in userProfileResult.UserProfile)
    
         {
    
          /* (PersonalSpace is the name of the path to a user's OneDrive for Business site. Users who have not yet created a OneDrive for Business site might not have this property set.)*/
    
         if (u.Values.Length != 0 && u.Values[0].Value != null && u.Name == "PersonalSpace" )
             
       {   personalUrl = u.Values[0].Value as string;
    
                break;
             }
        }
    
        int nextIndex = -1;
        nextIndex = Int32.Parse(userProfileResult.NextValue);                           
        userProfileResult = uprofService.GetUserProfileByIndex(nextIndex);
    
    }
