    public class Employee
    {
       public int ID { get; set; }
       public string Name { get; set; }
       public string Age { get; set; }
       public string Address { get; set; }
       public string ContactNo { get; set; }
       public override bool Equals(object obj)
       {
          var employee = obj as Employee;
          if (employee == null) return false;
          return employee.ID == ID;
       }
    }
