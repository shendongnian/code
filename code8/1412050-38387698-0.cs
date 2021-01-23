    foreach (Control c in panel.Controls)
    {
    	string cType = c.GetType().ToString();
    
    	// check all buttons
    	if (cType == "System.Web.UI.WebControls.Button")
    	{
    		if(((Button)c).Text == "Hello")
    		{
    		
    		}
    	}
    }
