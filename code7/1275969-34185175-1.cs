    public List<Models.EmployeeInfo> GetEmployeeInfo(SPListItemCollection splic)
    {
        var listEmployeeInfo = new List<Models.EmployeeInfo>();
		var propertyNames = new List<string>(){"EmployeeName","Position","Office","IsPublic"}
		
        foreach (SPListItem item in splic)
        {
            var employeeInfo = new Models.EmployeeInfo(); 
		    foreach (var propertyName in propertyNames)
			{  
			    string newData = "";
				if (item[propertyName] != null)
				{
					newData = item[propertyName];
				}
				employeeInfo.GetType().GetProperty(propertyName).SetValue(employeeInfo, newData, null); 
			}
            listEmployeeInfo.Add(employeeInfo);
		}
        return listEmployeeInfo;
	}
