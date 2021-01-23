    protected void btnSaveData_OnClick(object sender, EventArgs e)
    {
        // Check if duplicate data
        bool isDuplicate = ...
        if (isDuplicate)
        {
            hiddenOverwriteData.Value = "true";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ConfirmSave", "confirmSaveData();", true);
        }
        else
        {
            DoSaveData();
        }
    }
    private void DoSaveData()
    {
        // Actually save the data
        ...
    }
