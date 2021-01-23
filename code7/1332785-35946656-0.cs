    public class Student
    {    
        private readonly Lazy<IEnumerable<Course>> courses;
     
        public int Id { get; set; }
        public IEnumerable<Course> Courses => this.courses.Value;
     
        public Student()
        {
            this.courses = new Lazy<IEnumerable<Course>>(LoadCourses);
        }
     
        private IEnumerable<Course> LoadCourses()
        {
            var sql = "custom SQL query that uses this.Id after it's loaded";
            return MapEntitiesFromDb(sql);
        }
    }
