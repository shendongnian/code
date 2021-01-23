    List<Employee> employees = new List<Employee>();
    
    using (StreamReader sr = new StreamReader("filepath"))
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            string[] split = line.Split(" ".ToCharArray());
            employees.Add(new Employee
            {
                FirstName = split[0],
                LastName = split[1],
                EmployeedID = Int32.Parse(split[2]),
                StartYear = Int32.Parse(split[3]),
                InitialSalary = Decimal.Parse(split[4])
            });
        }
    }
