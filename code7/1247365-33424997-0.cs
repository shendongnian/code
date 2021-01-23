    void Start(){
        if(!FB.IsInitialized){
            FB.Init(OnInit)
        } else {
            OnInit()
        }
    }
    void OnInit(){
        if(!FB.IsInitialized) Debug.LogError("Failed to Initialize");
        if(!FB.IsLoggedIn){
            FB.LogInWithReadPermissions(mPermissions, AuthCallback);
        } else {
            OnFBConnected();
        }
    }
    
    void AuthCallback(ILoginResult r)
    {
        if (!string.IsNullOrEmpty(r.Error))
        {
            Debug.LogError("OnFBConnected: failed");
            return;
        }
        if (FB.IsLoggedIn)
        {
            OnFBConnected();
        }
        else
        {
            Debug.LogWarning("User cancelled facebook login.");
        }
    }
    
    void OnFBConnected(){
        //Do whatever you need with the AccessToken you have
    }
