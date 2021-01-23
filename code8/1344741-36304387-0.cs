    //In your designer file
    ddDeviceSelector.DataBound += new System.EventHandler(ddDeviceSelector_DataBound);
    protected void ddDeviceSelector_DataBound(object sender, EventArgs e)
    {
        String rowID = null;
        rowID = Request.QueryString["rid"];
        if (rowID != null)
        {
            setUiPropertiesByMode(classConstants.editMode);
            ddDeviceSelector.Enabled = true;
            ddDeviceSelector.Enabled = true;
            ddDeviceSelector.SelectedValue = rowID;
        }
    }
