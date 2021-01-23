    using System.Data.Entity.SqlServer;
    ...
    Expression<Func<Occurrence, TimeGrouper>> GetGrouper(int grouping)
    {
        switch (grouping)
        {
            case 1:
                return o => new TimeGrouper
                            { 
                                Year = o.occurrenceDate.Year
                            };
            case 2:
                return o => new TimeGrouper 
                            { 
                                Year = o.occurrenceDate.Year,
                                Month = o.occurrenceDate.Month
                            };
            case 3:
                return o => new TimeGrouper 
                            {
                                Year = o.occurrenceDate.Year,
                                Week = SqlFunctions.DatePart("wk", o.StartDate).Value
                            };
            default:
                return o => new TimeGrouper
                            {
                                Year = o.occurrenceDate.Year,
                                Day = SqlFunctions.DatePart("dy", o.StartDate).Value
                            };
        }
    }
