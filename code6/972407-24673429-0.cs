    public Dictionary<string, string> GetEmployeesAllLevels(int managerId)
    {
      return GetEmployeesAllLevels(managerId, null);
    }
        
    private Dictionary<string, string> GetEmployeesAllLevels(int managerId, Dictionary<string, string> existingList)
    {
      if (existingList == null) existingList = new Dictionary<string, string>();
      var lstSelectedEmployees1 = lstAllUser.Where(emp => emp.ManagerId == managerId)
                                          .Select(emp => new { 
                                              EmployeeName = emp.UserDetail.Name, 
                                              ManagerName = emp.Manager.UserDetail.Name,
                                              UserId = emp.UserId 
                                        }).ToList();
      foreach(var emp in lstSelectedEmployees1)
      {
        existingList.Add(emp.EmployeeName, emp.ManagerName);
        existingList = GetEmployeesAllLevels(emp.UserId, existingList);
      }
      return existingList;
    }
