     void Update () { 
                if (Input.GetMouseButtonDown (0)) {
                    if(OT.Over(shareBtn)) {
                     if (FB.IsLoggedIn)
                       {
                          CallFBFeed();  
                       } 
                       else 
                       {
                         FB.Login("email,publish_actions", LoginCallback); 
                       }                      
                    }
                }
             }
    void LoginCallback(FBResult result)
        {
            if (result.Error != null)
                lastResponse = "Error Response:\n" + result.Error;
            else if (!FB.IsLoggedIn)
            {
                lastResponse = "Login cancelled by Player";
            }
            else
            {
                lastResponse = "Login was successful!";
    CallFBFeed();  
            }
        }
