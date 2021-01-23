    public class AttendanceDisplayModel
    {
        //The rest of the propertis as you have them
        public int Late { get; set; }
        public string LateFormatted{ get{ return new TimeSpan((double)Late).ToString(@"hh\:mm\:ss"); } }
        public int Early{ get; set; }
        public string EarlyFormatted{ get{ return new TimeSpan((double)Early).ToString(@"hh\:mm\:ss"); } }
    }
        public List<AttendanceDisplayModel> GetAttendanceById(string userId)
        {
            TimeSpan StartTime = TimeSpan.Parse("9:00:00");
            TimeSpan EndTime = TimeSpan.Parse("18:00:00");
            return travelContext.Attendances.Where(a => a.UserId == userId).Select(s => new AttendanceDisplayModel()
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
                      Late = EntityFunctions.DiffMinutes(StartTime, s.InTime),
                      Early = EntityFunctions.DiffMinutes(s.InTime, StartTime),
                      LeaveId = s.LeaveId,
                      OverTime = s.OverTime,
                      UserId = s.UserId,
                      WeekOff = s.WeekOff,
                      WorkHour = s.WorkHour
                  }).ToList();
        }
