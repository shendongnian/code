    Protected void GetControlValues(ControlCollection  controls)
    {
        var holdList = new List<string>();
        foreach(Control c in controls)
    	{
		    if(c is System.Web.UI.WebControls.TextBox)
		    {
                holdList.Add(c.Text); //this will get the value of the TextBox 
		    } 
		    else if (c.controls.Count > 0)
		    {
			    GetControlValues(c.Controls)
		    }
    	}
    }
