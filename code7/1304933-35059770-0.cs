    //
    // This shows how to authenticate on both iOS 6.0 and older versions
    //
    if (UIDevice.CurrentDevice.CheckSystemVersion (6, 0)) {
        //
        // iOS 6.0 and newer
        //
        GKLocalPlayer.LocalPlayer.AuthenticateHandler = (ui, error) => {
    
            // If ui is null, that means the user is already authenticated,
        // for example, if the user used Game Center directly to log in
    
        if (ui != null)
                current.PresentModalViewController (ui, true);
        else {
            // Check if you are authenticated:
            var authenticated = GKLocalPlayer.LocalPlayer.Authenticated;
        }
        Console.WriteLine ("Authentication result: {0}",err);
        };
    } else {
        // Versions prior to iOS 6.0
        GKLocalPlayer.LocalPlayer.Authenticate ((err) => {
            Console.WriteLine ("Authentication result: {0}",err);
        });
    };
