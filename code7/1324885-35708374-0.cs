    Protected void GetControlValues(ControlCollection  controls)
    {
        foreach(Control c in controls)
    	{
    		if (c is System.Web.UI.WebControls.DropDownList)
    		{
    			DropDownList dl = c as DropDownList;
    			var value = dl.Items.Value;
    		}
    		else if (c.controls.Count > 0)
    		{
    			GetControlValues(c.Controls)
    		}
    	}
    }
