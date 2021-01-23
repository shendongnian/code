    List<Foo> employees = new List<Foo>();
    Foo employee = new Foo();
    employee.Name = "Emp1";
    employee.Bars = new List<Bar>();
    employee.Bars.Add(new Bar { Name = "Alpesh", IsActive = true });
    employee.Bars.Add(new Bar { Name = "Krunal", IsActive = true });
    employee.Bars.Add(new Bar { Name = "Karthik", IsActive = false });
    employee.Bars.Add(new Bar { Name = "Rakesh", IsActive = true });
    employees.Add(employee);
