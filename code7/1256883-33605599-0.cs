    protected object UniGrid_OnExternalDataBound(object sender, string sourceName, object parameter)
    {
        ContextResolver resolver = CMSContext.CurrentResolver.CreateContextChild();
        DataRowView drv;
        switch (sourceName.ToLower())
        {
            case "yourcolumn":
                drv = (DataRowView)parameter;
                CheckBox chk = new CheckBox();
                chk.ID = "chkDoc";
                chk.CssClass = "normalcheckbox";
                chk.InputAttributes.Add("Value", ValidationHelper.GetString(drv["NodeGUID"], string.Empty));
                return chk;
        } 
    }
