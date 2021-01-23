    namespace ContosoUniversity.DAL
    {
        public class StudentRepository : IStudentRepository, IDisposable
        {
            private SchoolContext context;
    
            public StudentRepository(SchoolContext context)
            {
                this.context = context;
            }
    
            public IEnumerable<Student> GetStudents()
            {
                return context.Students.ToList();
            }
            // ... more
