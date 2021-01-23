    public class Person
    {
      public int PersonId { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
    
      public ICollection<PersonCourse> PersonCourses { get; set; }
    }    
    public class Course
    {
      public int CourseId { get; set; }
      public string Title { get; set; }
    
      public ICollection<PersonCourse> PersonCoursess { get; set; }
    }
    public class PersonCourse {
    	[Key, Column(Order = 0)]
    	public int PersonId { get; set; }
    	[Key, Column(Order = 1)]
        public int CourseId { get; set; }    
        public int Quantity { get; set; }
        public Person Person { get; set; }
        public Course Course { get; set; }
    }
