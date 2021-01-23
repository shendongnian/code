    private void UpdateInstructorCourses(string[] selectedCourses, Instructor 
    instructorToUpdate)
    {
       if (selectedCourses == null)
       {
          instructorToUpdate.Courses = new List<Course>();
          return;
       }
     
       var selectedCoursesHS = new HashSet<string>(selectedCourses);
       var instructorCourses = new HashSet<int>
           (instructorToUpdate.Courses.Select(c => c.CourseID));
       foreach (var course in db.Courses)
       {
          if (selectedCoursesHS.Contains(course.CourseID.ToString()))
          {
             if (!instructorCourses.Contains(course.CourseID))
             {
                instructorToUpdate.Courses.Add(course);
             }
          }
          else
          {
             if (instructorCourses.Contains(course.CourseID))
             {
                instructorToUpdate.Courses.Remove(course);
             }
          }
       }
    }
