    courses.ForEach(FormatDetailsForDisplay);
    
    public void FormatDetailsForDisplay(Course v)
        {
            string f = String.Format("Course ID: {0} - Course Name: {1} ", v.CourseId, v.Name);
            foreach (var item in v.Students)
            {
                f += "Student Name:" + item.Name;
            }
            resultLabel.Text += f;
        }
