    protected void Page_Load(object sender, EventArgs e)
    {
    	try
    	{
    		pnlModuleContainer.Visible = false;
    		if (User.Profile.GetPropertyValue("CustomFieldName") == "somevalue")
    		{
    			pnlModuleContainer.Visible = true;
    		}
    		else
    		{
    			DotNetNuke.UI.Skins.Skin.AddModuleMessage(this, "You need 'somevalue' to see this module",
    						DotNetNuke.UI.Skins.Controls.ModuleMessage.ModuleMessageType.BlueInfo);
    		}
    	}
    	catch (Exception exc) //Module failed to load
    	{
    		Exceptions.ProcessModuleLoadException(this, exc);
    	}
    }
