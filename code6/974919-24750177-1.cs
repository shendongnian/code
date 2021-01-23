    public List<Course> GetCourses(int StudentID)
    {
        MyLearningEntities xEntity = new MyLearningEntities();
        List<Course> xList = new List<Course>();
        Student xStudent = default(Student);
        xStudent = (from x in xEntity.Students.Include("Courses") where x.StudentID == StudentID select x).FirstOrDefault();
        if (xStudent != null)
            return xStudent.Courses.ToList;
        else
            return xList;
    }
