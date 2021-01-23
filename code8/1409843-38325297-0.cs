    HashSet<int> employeeServiceTypes = new HashSet<int>();
    if (employee != null && employee.ServiceTypes != null)
    {
        foreach (int id in employee.ServiceTypes.Select(c => c.Id))
        {
            employeeServiceTypes.Add(id);
        }
    }
