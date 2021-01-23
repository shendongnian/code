    employeeInfo.EmployeeName = ConditionalToString(item, "EmployeeName");
    employeeInfo.Position = ConditionalToString(item, "Position");
    employeeInfo.Office = ConditionalToString(item, "Office");
    employeeInfo.IsPublic = item[attrName] == null ? false : Convert.ToBoolean("IsPublic");
    string ConditionalToString(SPListItem item, string attrName)
    {
        return (item[attrName] == null ? "" : item[attrName].ToString());
    }
