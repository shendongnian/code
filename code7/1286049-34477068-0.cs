    private IEnumerable<Employee> ApplyFilters()
    {
        var filters = new List<Func<Employee, bool>>();
        if (!string.IsNullOrWhiteSpace(nameTextBox.Text))
        {
            filters.Add(emp => emp.Name == nameTextBox.Text);
        }
        int age;
        if (int.TryParse(ageTextBox.Text, out age))
        {
            filters.Add(emp => emp.Age > age);
        }
        int id;
        if (int.TryParse(idTextBox.Text, out id))
        {
            filters.Add(emp => emp.Id > id);
        }
        // Use this to find employees that fulfil any condition
        // var filteredOutEmployees = employees.Where(e =>
        // {
        //     return filters.Any(f => f(e));
        // });
        // Use this to select the emplyees that fulfil all the conditions
        var filteredOutEmployees = employees.Where(e =>
        {
            return filters.All(f => f(e));
        });
        return filteredOutEmployees;
    }
