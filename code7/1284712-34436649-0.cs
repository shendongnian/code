    var grouped = (
        from s in context.Table
        group s by new { s.AttendanceDate.Year, s.AttendanceDate.Month } into g
        select new { Year = g.Key.Year, Month = g.Key.Month, Attendance = g.Sum(s => s.Attendance) }
    );
