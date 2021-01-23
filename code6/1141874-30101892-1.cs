    CustomKeyInputManager keyInputManager;
    
    Initialize()
    {
    	keyInputManager = CustomKeyInputManager();
    	keyInputManager.RegisterKey("pause", Keys.P);
    }
    Update(GameTime pGameTime)
    {
    	keyInputManager.Update(pGameTime);	
    	if (keyInputManager["pause"].IsPressedAndNotHandled)
    	{
    		pause != pause;
    		keyInputManager["pause"].SetHandled();
    	}
    }
