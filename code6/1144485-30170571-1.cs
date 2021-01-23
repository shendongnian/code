    public IEnumerable<Employee> GetEmployees(TextReader stream)
    {
        var exisiting = new HashSet<int>();
        using (var reader = MyLibraryFunction(stream)
        {
            while (reader.Read())
            {
                var employee = Employee.Create(reader);
                if (exisiting.Add(employee.Id)) {
                    yield return Employee.Create(reader);
                }
            }
        }
    }
