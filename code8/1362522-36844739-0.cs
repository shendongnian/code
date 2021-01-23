    private DateTime GetNextFutureDate(Course course)
    {
        var dates =
            new[] {course.Date1, course.Date2, course.Date3, course.Date4, course.Date5}.Where(d => d > DateTime.Now).ToArray();
        return dates.Length == 0 ? DateTime.MaxValue : dates[0];
    }
