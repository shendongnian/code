    public List<Models.EmployeeInfo> GetEmployeeInfo(SPListItemCollection splic)
    {
    
      var listEmployeeInfo = new List<Models.EmployeeInfo>();
      foreach (SPListItem item in splic)
      {               
        var employeeInfo = new Models.EmployeeInfo();
    
        employeeInfo.EmployeeName = item["EmployeeName"] == null ? "" : item["EmployeeName"].ToString();
    
        employeeInfo.Position = item["Position"] == null ? "" : item["Position"].ToString();
        employeeInfo.Office = item["Office"] == null ? "" : item["Office"].ToString();
    
        employeeInfo.IsPublic = item["IsPublic"] == null || Convert.ToBoolean("IsPublic");
    
        listEmployeeInfo.Add(employeeInfo);
      }
    
      return listEmployeeInfo;
    }
