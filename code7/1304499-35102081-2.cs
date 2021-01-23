    // Grab from db list of courses and their dates. 
    // Put dates in a List of DateTime, but you can also use DateTime2.
    // Note that courses will be an IQueryable.
    var courses = db.Courses.Select(course => new List<DateTime> {
        Dates = db.Dates
            .Where(date => date.CourseID == course.ID)
            .Select(date => date._Date).ToList()
    });
    // Extract data from SQL by calling our IQueryable's ToList() of method. This puts the data as a List in memory.
    // Using the List.Select() method, convert dates to strings. This will return an IEnumerable.
    // Convert the resulting IEnumerable back to a List.
    return courses
              .ToList()
              .Select(course => new Model.Course
              {
                 // Here, you are using the .NET Framework's DateTime.ToString()
                 // So you can use any formatting options available with that.
                 Dates = course.Dates.Select(date => date.ToString()).ToList()
              })
              .ToList();
