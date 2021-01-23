    public class Student{
       public int Id{get; set;}
       public string StudentName{get; set;}
       public IList<StudentsSubjects> Subjects{get; set;}
       // other properties
    }
    public class Subject{
       public int Id{get; set;}
       public string SubjectTitle{get; set;}
       public IList<StudentsSubjects> Students{get; set;}
       // other properties
    }
    public class StudentsSubjects{
      public int Id{get; set;}
      public int StudentId{get; set;}
      public int SubjectId{get; set;}
      public DateTime DateAdded{get; set;}
    }
    
