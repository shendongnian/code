     public class Student
     {
         public string Id { get; set; }
         public List<string> Marks { get; set; }
    
         public Student()
         {
             this.Marks = new List<string>();
         }
     }
