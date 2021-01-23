    var UserEvents = from e in _context.Events
                     join s in _context.Shifts on e.ShiftID equals s.SHFID
                     join a in _context.Areas on e.AreaID equals a.AreaID
                     where e.UID == userID
                     select new UserEvents
                     {
                         EVTID = e.EVTID,
                         UID = e.UID,
                         ShiftID = e.ShiftID,
                         EVTDate = e.EVTDate,
                         Notes = e.Notes,
                         AreaID = a.AreaID,
                         AreaDesc = a.AreaDesc,
                         CPYDesc = a.Company.CPYDesc,
                         StartTime = s.StartTime,
                         EndTime = s.EndTime,
                         RequiredResources = s.RequiredResources,
                         ShiftDesc = s.ShiftDesc,
                         ShiftDayOfWeek = s.ShiftDayOfWeek
                     };
