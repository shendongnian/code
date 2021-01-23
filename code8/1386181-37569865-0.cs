    string BizID = DT1["Business_ID"]?.ToString(); // add null conditional operator in case it is null.
    if (!string.IsNullOrEmpty(BizID))
    {
       DDLBustype.SelectedValue = BizID;
    }
