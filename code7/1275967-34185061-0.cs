    public List<Models.EmployeeInfo> GetEmployeeInfo(SPListItemCollection splic)
    {
        var listEmployeeInfo = new List<Models.EmployeeInfo>();
        foreach (SPListItem splicItem in splic)
        {               
          listEmployeeInfo.Add(CreateEmployeeInfoFromItem(splicItem));
        }
        return listEmployeeInfo;
    }
    private static Models.EmployeeInfo CreateEmployeeInfoFromItem(SPListItem item)
    {
        var employeeInfo = new Models.EmployeeInfo();
        employeeInfo.EmployeeName = item["EmployeeName"] == null ? "" : item["EmployeeName"].ToString();
        employeeInfo.Position = item["Position"] == null ? "" : item["Position"].ToString();
        employeeInfo.Office = item["Office"] == null ? "" : item["Office"].ToString();
        employeeInfo.IsPublic = item["IsPublic"] == null || Convert.ToBoolean("IsPublic");
        return employeeInfo;
    }
