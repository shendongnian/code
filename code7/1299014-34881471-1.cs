    Employees employees = new Employees();
    employees.Add(new Employee(1, "David", "Smith", 10000));
    employees.Add(new Employee(3, "Mark", "Drinkwater", 30000));
    employees.Add(new Employee(4, "Norah", "Miller", 20000));
    employees.Add(new Employee(12, "Cecil", "Walker", 120000));
    XmlSerializer ser = new XmlSerializer(typeof(Employees));
    ser.Serialize(Console.OpenStandardOutput(), employees);
    Console.ReadKey();
