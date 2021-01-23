    protected void gvData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataObject dataObject;
        CompareValidator valueMinValidator;
        string description, errorMessage;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            dataObject = (DataObject)e.Row.DataItem;
            valueMinValidator = (CompareValidator)e.Row.FindControl("ValueMinValidator");
            description = dataObject.Description;
            errorMessage = string.Format("{0} below minimum {1}", description, dataObject.Minimum); //localize dataObject.Minimum as needed
            valueMinValidator.ErrorMessage = errorMessage;
            valueMinValidator.ToolTip = errorMessage;
        }
    }
