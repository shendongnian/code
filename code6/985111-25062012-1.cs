    protected void Button1_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(
            this,
            this.GetType(),
            UniqueID,
            "confirmDuplicateCustomerCreation();",
            true);
    }
    
    protected void HiddenField1_ValueChanged(object sender, EventArgs e)
    {
        if (Convert.ToBoolean(HiddenField1.Value))
        {
            // User clicked OK at Confirmation   
        }
    }
