    public IEnumerable<Employee> Get()
    {
       // There could be such constraint as illustrated
       return employees.Where(x => x.Department == "HR").Take(100);
    }
