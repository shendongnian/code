    courses.ForEach(FormatDetailsForDisplay);
    
    public void FormatDetailsForDisplay(Course course)
    {
       string f = String.Format("Course ID: {0} - Course Name: {1} ", course.CourseId, course.Name);
       foreach (var item in course.Students)
       {
         f += "Student Name:" + item.Name;
       }
         resultLabel.Text += f;
    }
