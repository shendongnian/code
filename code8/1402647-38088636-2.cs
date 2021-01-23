    List<Employee> empList = new List<Employee>();
    
    empList.Add(new Employee { FirstName = "Ziggy", LastName = "Walters", Wage = 132.50F });
    empList.Add(new Employee { FirstName = "Zoey", LastName = "Strand", Wage = 76.50F });
    
    using (StreamWriter sw = new StreamWriter(@"C:\Temp\emp.csv"))
    using (CsvWriter cw = new CsvWriter(sw))
    {
        cw.WriteHeader<Employee>();
    
        foreach (Employee emp in empList)
        {
            emp.Wage *= 1.1F;
            cw.WriteRecord<Employee>(emp);
        }
    }
