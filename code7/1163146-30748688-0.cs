    var ikj = Model.EmployeeInformationList
                   .Select(m => new HolidayAlwEmployeeInfo(
                                    m.GEmployeeGenInfoID,
                                    m.strDesignationName,
                                    m.strEmpOldCardNo,
                                    m.StrEmpID,
                                    m.GFactoryID,
                                    m.StrEmpName ))
                   .Distinct()
                   .ToList();
