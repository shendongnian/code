    public String getEmployeeByID(string empName)
    {
        LinqToSqlDataContext database = new LinqToSqlDataContext();
        return database.Persons.FirsOrDefault(emp => emp.personName.Contains(empName)).ID;
    }
