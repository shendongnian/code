    IEnumerable<Schedule.Day> scheduledDays =
      from subj in subjList
      from cl in subj.Data
      select new { Class = cl, SubjectName = subj.Name } into classWithSubject
      group classWithSubject by classWithSubject.Class.Day into classesByDay
      orderby classesByDay.Key
      select new Schedule.Day()
      {
        DayOfWeek = classesByDay.Key,
        Subjects = (from cl in classesByDay
                    orderby cl.Class.Time
                    select new Schedule.Subject() { Name = cl.SubjectName, Time = cl.Class.Time }).ToList()
      };
    Schedule sched = new Schedule() { Days = scheduledDays.ToList() };
