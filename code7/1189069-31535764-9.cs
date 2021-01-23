    protected void Page_Load(object sender, EventArgs e)
    {
        // To disable "Send All" option in DropDown
        DisableItemInDropDown("Send All");
    
        // To disable "Remove" option in DropDown
        DisableItemInDropDown("Remove");
    }
    
    protected void DisableItemInDropDown(string ddlItemValueText)
    {
        foreach (DropDownListItem item in ddlAction.Items)
        {
            if (item.Value == ddlItemValueText)
            {
                item.Enabled = false;
            }
        }
    }
