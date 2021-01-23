    public class CreateStudentVM
    {        
        public string Name { set; get; }      
        public List<CourseSelection> Courses { set; get; }
    
        public CreateStudentVM()
        {
            this.Courses=new List<CourseSelection>();
        }
    }
    public class CourseSelection
    {
        public int CourseId { set; get; }
        public string CourseName { set; get; }
        public bool IsSelected { set; get; }
    }
