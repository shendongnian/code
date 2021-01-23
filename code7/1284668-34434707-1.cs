    void Main()
    {
      var objs = new List<Student>()
     {
       new Student() {
        Name = "Manish",
        Address = "MUM",
        StudentMarks = new List<Mark> {
          new Mark {Name="Eng", Score = 50},
          new Mark {Name="Maths", Score = 60},
          }
        },
    new Student() {
        Name = "Manoj",
        Address = "MUM",
        StudentMarks = new List<Mark> {
          new Mark {Name="Maths", Score = 100},
          new Mark {Name="Eng", Score = 80},
          new Mark {Name="Eng", Score = 70},
          new Mark {Name="Eng", Score = 90},
          new Mark {Name="Maths", Score = 90},
          }
        },
     };
          
      foreach (var student in objs)
      {
        Console.WriteLine("{0} - {1}", student.Name, student.Address);
        foreach (var mark in student.StudentMarks)
        {
          Console.WriteLine("Name:{0}, Score:{1}", mark.Name, mark.Score);
        }
      }
    }
    
    public class Mark
    {
      public string Name { get; set; }
      public int Score { get; set; }
    }
    
    public class Student
    {
      public string Name { set; get; }
      public string Address { set; get; }
      public List<Mark> StudentMarks { set; get; }
    }
