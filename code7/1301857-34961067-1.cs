    public List<tblCourse> editedCoursesView()
    {
        List<tblCourse> data;
        using (enrolmentsystemEntities db = new enrolmentsystemEntities())
        {
            data = db.tblCourses
              .Include(c => c.tblSection)
              .Include(c => c.tblSection.tblRoom)
              .ToList();
            return data;
        }
    }
      
  
