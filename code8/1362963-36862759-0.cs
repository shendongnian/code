    public class Student {
        public string Id {get;set;}           // Weird this is a string not int
        public string  EnrollTime {get;set;}  // Weird this is a string not date
        public int Course  {get;set;}
    }
    public class StudentCatalogContext : DbContext
    {
        public virtual IDbSet<Student> Student { get; set; }
    }
    public class StudentRepository
    {
        private StudentCatalogContext _studentCatalogContext;
        public StudentRepository(StudentCatalogContext context)
        {
            _studentCatalogContext = context;
        }
        public List<Student> GetAllStudents()
        {
            return _studentCatalogContext.Student.Where(x => (x.Course != 2 && x.Course != 6))
                                         .OrderByDescending(x => x.EnrollTime).ToList();
        }
    }
