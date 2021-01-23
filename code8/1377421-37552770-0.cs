    public class SelectFileAction : TriggerAction<FrameworkElement>
    {
    	protected override void Invoke( object parameter )
    	{
    		ISelectFilePayload payload = notification.Content as ISelectFilePayload;
    
    		// Configure the open file dialog
    		Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
    		dlg.Filter = payload.Filter;
    
    		// Show the dialog 
    		Nullable<bool> result = dlg.ShowDialog();
    
    		// Process dialog result
    		if (result == true)
    		{
    			// Return the name of the selected file in the payload
    			payload.Path = dlg.FileName;
    
    			// The Callback property, if set, contains the invoker's callback method
    			var callback = args.Callback;
    
    			// Call the invoker's callback if any
    			if (callback != null)
    			{
    				callback();
    			}
    		}
    	}
    }
