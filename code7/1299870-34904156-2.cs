    public List<String> getEmployeeByID(string empName)
    {
        LinqToSqlDataContext database = new LinqToSqlDataContext();
        return database.Persons.Where(emp => emp.personName.Contains(empName)).Select(c => c.ID).ToList();
    }
