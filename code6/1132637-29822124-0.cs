    public class CourseSchedule
    {
        public CourseSchedule(Course course, Student[] students, Teacher[] teacher)
        {
            this.Course = course;
            ....
        }
        // Some sort of Date too
        public Course Course { get; private set; }
        public IEnumerable<Student> Students { get; private set; }
        public IEnumerable<Teacher> Teachers { get; private set; }
    }
