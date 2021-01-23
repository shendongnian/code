    return travelContext.Attendances.Where(a => a.UserId == userId).ToList().Select(s => new AttendanceDisplayModel()
                  {
                      Id = s.Id,
                      EmployeeNumber = s.EmployeeNumber,
                      Absent = s.Absent,
                      AttendanceDate = s.AttendanceDate,
                      BelowTime = s.BelowTime,
                      CompanyId = s.CompanyId,
                      CompOffId = s.CompanyId,
                      HoliDayId = s.HoliDayId,
                      InTime = s.InTime,
                      OutTime = s.OutTime,
                      ISCompOFF = s.ISCompOFF,
                      Late = TimeSpan.FromMinutes(StartTime - s.InTime).ToString(@"hh\:mm\:ss"),
                      Early = TimeSpan.FromMinutes(s.InTime - StartTime).ToString(@"hh\:mm\:ss"),
                      LeaveId = s.LeaveId,
                      OverTime = s.OverTime,
                      UserId = s.UserId,
                      WeekOff = s.WeekOff,
                      WorkHour = s.WorkHour
                  });
