    public class RegularEmployeeHandler : EmployeeHandler
    {
      public RegularEmployeeHandler(EmployeeHandler nextHandler) : base(nextHandler) {
      }
      protected override bool CanHandle(Employee emp)
      {
        return emp.Positions.Count == 1 && emp.Positions[0] == "Regular";
      }
      protected override string GetQuery(Employee emp)
      {
        return "some regular query";
      }
    }
    public class OfficeDirectorEmployeeHandler : EmployeeHandler
    {
      public OfficeDirectorEmployeeHandler(EmployeeHandler nextHandler) : base(nextHandler) {
      }
      protected override bool CanHandle(Employee emp)
      {
        return emp.Positions.Count == 1 && emp.Positions[0] == "OfficeDirector";
      }
      protected override string GetQuery(Employee emp)
      {
        return "some office director query"; 
      }
    }
    public class AdminEmployeeHandler : EmployeeHandler
    {
      public AdminEmployeeHandler(EmployeeHandler nextHandler) : base(nextHandler) {
      }
      protected override bool CanHandle(Employee emp)
      {
        return emp.Positions.Count == 1 && emp.Positions[0] == "Admin";
      }
      protected override string GetQuery(Employee emp)
      {
        return "some admin query"; 
      } 
    }
    public class RegularAndOfficeDirectorEmployeeHandler : EmployeeHandler
    {
      public RegularAndOfficeDirectorEmployeeHandler(EmployeeHandler nextHandler) : base(nextHandler) {
      }
      protected override string GetQuery(Employee emp)
      {
        return "some regular and director query";
      }
      protected override bool CanHandle(Employee emp)
      {
        return emp.Positions.Count == 2 && emp.Positions.Contains("Regular") && emp.Positions.Contains("OfficeDirector");
      }
    }
