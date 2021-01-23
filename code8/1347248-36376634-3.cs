    protected void Page_Load(object sender, EventArgs e)
    {
        using (var dbContext = new MyModel())
        {
            var students = (from student in dbContext.Students
                            /*optional where clause*/
                            select new
                                   {
                                       Name = student.StudentName,
                                       Courses = student.Courses.Select(c => c.CourseName)
                                   }).ToList();
            GridView1.DataSource = students.Select(s => new { s.Name, Courses = String.Join(",", s.Courses)}).ToList();
            GridView1.DataBind();
        }
    }
