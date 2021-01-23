    public class Student
    {
       //...
       public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
    public class Course
    {
      //...
      public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
    public class Enrollment
    {
      //...
      public virtual Student Student { get; set; }
      public virtual Course Course { get; set; }
    }
