    public class Assignment
    {
      public Employee Employee { get; set; }
      public Request Request { get; set; }
      public Assignment()
      {
        Employee = new Employee();
        Request = new Request();
      }
    }
