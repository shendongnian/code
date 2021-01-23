    public void someFunction() {
        AppDelegate appD = UIApplication.SharedApplication.Delegate as AppDelegate;
    
    	// assign the UINavigationController to the variable being used to push
    	appD.navCtrl = this.NavigationController;
        /*
        .
        . the rest of the codes
        .
        */
    }
