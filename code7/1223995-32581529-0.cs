    private void MyAddin_Startup(object sender, System.EventArgs a)
    {
        this.Application.DocumentChange += new ApplicationEvents4_DocumentChangeEventHandler(Application_DocumentChange);
    }
    
    private void Application_DocumentChange()
    {
    	bool enableButton = false;
    	if(yourdocument)   // put something here that checks the document you want the button to be enable in
    	{ 
    		enableButton = true;
    	}
    	CustomRibbon ribbon = Globals.Ribbons.CustomRibbon;
    	ribbon.button.Enabled = enableButton;
    }
