    var entries = context.CompletedCourses
        .Include(x => x.Agent)
        .Include(x => x.Course);
    var courses = entries.ToList();
    var courseIds = entries.Select(x => x.CompletedCourseId);
    var licenses =
        (from course in entries
            join license in context.Licenses
            on new { course.AgentId, course.Course.StateId } 
            equals new { AgentId = license.UserId, license.StateId }
            where courseIds.Contains(course.CompletedCourseId)
            select license);
    foreach (var course in courses)
    {
        var license = agentLicenses.FirstOrDefault(x => x.UserId == course.AgentId && 
            x.StateId == course.Course.StateId);
        if (license != null)
        {
            course.LicenseNumber = license.LicenseNumber;
        }
    }
    return courses;
