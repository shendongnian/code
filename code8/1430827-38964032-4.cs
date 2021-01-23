    public class SelectedCourse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
    public class StudentCourseVM
    {
        public int StudentId { set; get; }       
        public IEnumerable<SelectedCourse> SelectedCourses { get; set; }
    }
