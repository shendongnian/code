    public override void ViewDidLoad() {
        AppDelegate appD = UIApplication.SharedApplication.Delegate as AppDelegate;
    
    	// assign the UINavigationController to the variable being used to push
        // assuming that you have already initialised or instantiated a UINavigationController
    	appD.navCtrl = this.NavigationController; // Your UINavigation controller should be here
        /*
        .
        . the rest of the codes
        .
        */
    }
