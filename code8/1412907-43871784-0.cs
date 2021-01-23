    // get all courses 
    IEnumerable<Course> courses = context.Courses.ToList(); 
    // select tutor ids from courses (C# logic, without DB access)
    IEnumerable<int> tutorIds = courses.Select(c => c.TutorId);
    // select subject ids from courses (C# logic, without DB access)
    IEnumerable<int> subjectIds = courses.Select(c => c.SubjectId); 
    
    context.Tutors.Where( t => tutorIds.Contains(t.TutorId) ).Load();
    context.Subjects.Where( s => subjectIds.Contains(s.SubjectId) ).Load();
