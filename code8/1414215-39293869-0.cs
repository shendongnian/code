    private void Application_DocumentBeforeSave(Document Doc, ref bool SaveAsUI, ref bool Cancel)
    {
    	new Thread(() =>
    	{
    		while (true)
    		{
    			try
    			{
    				var application = document.Application; // This is inaccessible while the save file dialog is open, so it will throw exceptions.
    				while (application.BackgroundSavingStatus > 0) // Wait until the save operation is complete.
    					Thread.Sleep(1000);
    				break;
    			}
    			catch {
    				Thread.Sleep(1000);
    			}
    		}
    		// If we get to here, the user either saved the document or canceled the saving process. To distinguish between the two, we check the value of document.Saved.
    		Application_DocumentAfterSave(document, !document.Saved);
    	}).Start();
    }
    
    private void Application_DocumentAfterSave(Document Doc, bool isCanceled) {
    	// Handle the after-save event. Note: Remember to check isCanceled.
    }
