    // Grab from db list of courses and their dates. 
    // Put dates in a List of DateTime, but you can also use DateTime2.
    // Note that courses will be an IQueryable.
    var courses = db.Courses.Select(course => new List<DateTime> {
        Dates = db.Dates
            .Where(date => date.CourseID == course.ID)
            .Select(date => date._Date)
    });
    // Extract data from SQL using the ToList() of our IQueryable. 
    // This will give us a list in memory.
    // Using the List.Select(), convert dates to string in memory.
    // This will return an IEnumerable.
    // Convert the resulting IEnumerable to a list (optional).
    return courses.ToList().Select(course => new Model.Course
       {
            Dates = course.Dates.Select(date => date.ToString())
       })
       .ToList();
