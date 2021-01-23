    void Main()
    {
      var objs = new List<Student>()
     {
    new Student() {
        Name = "Manish",
        Address = "MUM",
        StudentMarks = new Dictionary<string,List<int>> {
          {"Maths", new List<int> {60,70,50}},
          {"Eng", new List<int> {80,70,90}},
          }
        },
    new Student() {
        Name = "Manoj",
        Address = "MUM",
        StudentMarks = new Dictionary<string,List<int>> {
          {"Maths", new List<int> {70,90}},
          {"Eng", new List<int> {40,50,60,60}},
          }
        },
     };
      foreach (var student in objs)
      {
        Console.WriteLine("{0} - {1}", student.Name, student.Address);
        foreach (var course in student.StudentMarks)
        {
          Console.WriteLine("Course:{0}, Average:{1}", course.Key, course.Value.Average());
          foreach (var score in course.Value)
          {
            Console.WriteLine(score); 
          }
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
      public Dictionary<string,List<int>> StudentMarks { set; get; }
    }
