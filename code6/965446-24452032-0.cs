    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        if (txtID.Text != "" || txtPassword.Text != "")
        {
    	    base.OnFormClosing(e);
    	    if (e.CloseReason == CloseReason.WindowsShutDown
    	        || e.CloseReason == CloseReason.ApplicationExitCall)
    		    	return;
    
        	// Confirm user wants to close
    	    using(var closeForm = new formConfirmExit())
    	    {
    	    	var result = closeForm.ShowDialog();
    	    	if (result == DialogResult.No)
    	    		e.Cancel = true;   
            }
        }		
    }
