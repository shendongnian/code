    public IEnumerable<Employee> Get()
    {
       // There could be such a constraint as illustrated below.
       // Note the Take(100), this is the constraint or restriction
       return employees.Where(x => x.Department == "HR").Take(100);
    }
