    PropertyInfo MasterTableView  => grdData.GetType().GetProperty("MasterTableView);
    PropertyInfo EditFormSettings => MasterTableView.PropertyType.GetProperty("EditFormSettings");
    PropertyInfo InsertCaption 
    {
        get { return EditFormSettings.Property.GetProperty("InsertCaption");
        set { EditFormSettings.Property.GetProperty("InsertCaption") = value}
    }
