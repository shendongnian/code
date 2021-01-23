    var targetList = Model.EmployeeInformationList
                          .Select(m => new HolidayAlwEmployeeInfo {
                              GEmployeeGenInfoID= m.GEmployeeGenInfoID,
                              strDesignationName= m.strDesignationName,
                              strEmpOldCardNo= m.strEmpOldCardNo,
                              StrEmpID= m.StrEmpID,
                              GFactoryID= m.GFactoryID,
                              StrEmpName = m.StrEmpName })
                          .Distinct()
                          .ToList();
