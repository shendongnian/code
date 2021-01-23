    public static List<Tuple<Absence,TimePeriod>> GetAbsencesByEmployeeIDAndYear(Int32 employeeID, Int32 year) {
    
        List<Tuple<Absence,TimePeriod>> absences = dataContext.Absences.Join(dataContext.TimePeriods,
         abs => abs.Period,
         tps => tps.IDTimePeriod,
         (abs, tps) => new { abs, tps})
         .Where(x => x.abs.Employee.IDEmployee == employeeID && x.tps.StartTime.Year == year)
        .Select(t => new Tuple<Absence,TimePeriod>(t.abs, t.tps))
        .ToList();
    
        return absences;
    }
