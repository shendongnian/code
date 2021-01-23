    protected void btnSaveData_OnClick(object sender, EventArgs e)
    {
        // Check if the data record already exists
        bool isDuplicate = ...
        if (isDuplicate)
        {
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
