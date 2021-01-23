    protected void PopulateDDLsections(object sender, EventArgs e)
    {
        int orgID;
        
        // Make sure we parse the selected value to an int.
        if(Int32.TryParse(ddlOrg.SelectedValue, orgID))
        {
            // Form the select statement from the orgID we just parsed.
            String command = String.Format("SELECT * FROM [ORG_SECTIONS] WHERE OrgID = {0}", orgID);
            // Assign the SelectCommand.
            AccessDataSource2.SelectCommand = command;
        }
        
    }
