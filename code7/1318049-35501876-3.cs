    static void Main(string[] args)
    {
      RegisterGenerator<IPerson, PersonQueryGenerator>();
      RegisterGenerator<IManager, ManagerQueryGenerator>();
      var managers = new List<IPerson>
      {
        new Manager
        {
          Birthday = DateTime.Now.AddDays(1),
          Name = "Executive Manager",
          EmployeeNumber = 9,
          IsExecutive = true,
          Salary = 1000
        },
        new Manager
        {
          Birthday = DateTime.Now.AddDays(-1),
          Name = "Ordinary Manager",
          EmployeeNumber = 8,
          IsExecutive = false,
          Salary = 900
        }
      }.AsEnumerable();
      var queries = GenerateQueries<IPerson>();
      managers = queries.Aggregate(managers, (current, expression) => current.Where(expression));
      foreach (var manager in managers)
      {
        Console.WriteLine("Manager: {0}", manager.Name);
      }
      Console.ReadKey();
    }
