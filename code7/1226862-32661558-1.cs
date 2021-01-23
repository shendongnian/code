    public class Student{
       public int Id {get; set;}
       public virtual ICollection<Registration> Registrations {get; set;}
    }
    
    public class Registration{
      public int Id {get; set;}
      public int StudentId {get; set;}
      public Student StudentEntity {get; set;}
    }
