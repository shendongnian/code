    var leaveDayPredicate = LeaveDayExpressions.IsInDatesRange(startDate, endDate);
    var result = this.ObjectContext.People.Select(p => new NewPeopleObject
    {
        Guid = p.Guid,
        FirstName = p.FirstName,
        LastName = p.LastName,
        LeaveDays = p.CalendarData.LeaveDays.AsQueryable()
            .Where(leaveDayPredicate)
            .Select(ld => new LeaveDaySummary
            {
                 StartDate = ld.StartDate,
                 EndDate = ld.EndDate,
            })
    });
