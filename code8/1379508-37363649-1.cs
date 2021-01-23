    var employeesParent = xDocument.Descendants("Employees").Where(element => element.Parent.Attribute("name").Value == departmentName);
    var employees = (from emp in employeesParent.Descendants()
                             select new Employee
                             {
                                 DepartmentName = departmentName,
                                 FirstName = emp.Attribute("FirstName").Value,
                                 Surname = emp.Attribute("Surname").Value
                             }).ToList();
