    var db = new YourDbContext();
    var result = (from t in db.Timetables
                    join c in db.ClassTimings on t.ClassTimingId equals c.Id
                    join e in db.Employees on t.StaffId equals e.StaffID
                    join d in db.Departments on t.DepartmentId equals d.Id
                    join s in db.Sections on t.SectionID equals s.Id
                    join cl in db.Classes on t.ClassID equals cl.Id
                    join w in db.WeekDays on t.WeekDayId equals w.Id
                    select
                        new { c.StartTime,
                              c.EndTime, e.StaffName,
                              d.DepartmentName,
                              cl.ClassName,
                              s.SectionName,
                              w.DayName
                            }
                ).ToList();
