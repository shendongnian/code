    void Main()
    {
      var objs = new List<Employee>()
    {
       new Employee() {
        empName = "Manish",
        empAddress = "MUM",
        StudentMarks = new Marks[] {
          new Marks {ENG=10, MATHS = 100},
          new Marks { ENG=20, MATHS = 80}, }},
       new Employee() {
      empName = "Manoj",
      empAddress = "MUM",
      StudentMarks = new Marks[] {
          new Marks { ENG=59, MATHS = 40},
          new Marks { ENG=60, MATHS = 80},
          new Marks { ENG=80, MATHS = 10},
          new Marks { MATHS = 90},
          new Marks { ENG=70},}
      },
    };
    
    foreach (var student in objs)
    {
      Console.WriteLine("{0} - {1}", student.empName, student.empAddress);
      foreach (var mark in student.StudentMarks)
      {
        Console.WriteLine("Eng:{0}, Maths:{1}", mark.ENG, mark.MATHS);
      }
    }
    }
    
    public class Marks
    {
      public int ENG { get; set; }
      public int MATHS { get; set; }
    }
    
    public class Student
    {
      public string empName { set; get; }
      public string empAddress { set; get; }
      public Marks[] StudentMarks { set; get; }
    }
    
    public class Employee : Student
    { }
