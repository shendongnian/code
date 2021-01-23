    public class PersonCourse
    {
       [Key, Column(Order = 0),ForeignKey("Person")]
       public int PersonId { get; set; }
       [Key, Column(Order = 1),ForeignKey("Course")]
       public int CourseId { get; set; }
    
       public Person Person { get; set; }
       public Course Course { get; set; }
       public int Quantity{ get; set; }
    }
    public class Person
    {
      public int PersonId { get; set; }
      //...
    
      public ICollection<PersonCourse> CoursesAttending { get; set; }
    
      public Person()
      {
        CoursesAttending = new HashSet<PersonCourse>();
      }
    }
    
    public class Course
    {//...public string Title { get; set; }
    
      public ICollection<PersonCourse> Students { get; set; }
    
      public Course()
      {
        Students = new HashSet<PersonCourse>();
      }
    }
