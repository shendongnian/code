    from pay in db.Payments
    from FlyRpt in db.FlightReportTickets
    where pay.ObjectIdDepartue == FlyRpt.DepartureId
    || FlyRpt.DepartureId == pay.ObjectIdReturn
    join prof in db.Profiles on FlyRpt.UserId equals prof.UserId
    where pay.ReserveType == 1 &&
    pay.Transactionsuccess &&
    pay.IssueDate >= fromDateTime &&
    pay.IssueDate <= toDateTime
    select new
    {
        FlyRpt.FullPrice,
    };
