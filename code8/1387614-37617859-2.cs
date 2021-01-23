    int bizColIndex = DT2.GetOrdinal("Business_ID");
    string BizID = (DT2.IsDBNull(bizColIndex) ? string.Empty : DT2.GetString(bizColIndex));
    if (!string.IsNullOrEmpty(BizID))
    {
        DDLBustype.SelectedValue = BizID;
    }
