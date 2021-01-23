    List<Employee> employees = new List<Employee>();
    XElement xElement = XElement.Load("Employees.xml");
    IEnumerable<XElement> xmlEmployees = xElement.Elements("Employee");
    foreach (var xmlEmployee in xmlEmployees)
    {
        Employee employee = new Employee();
        foreach (var item in xmlEmployee.Elements("item"))
        {
            string key = item.Element("key").Value;
            string value = item.Element("value").Value;
            switch (key)
            {
                case "Name":
                    employee.Name = value;
                    break;
                ...
            }
        }
        employees.Add(employee);
    }
