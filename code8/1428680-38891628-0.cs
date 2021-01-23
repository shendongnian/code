    listDates = new List<DateTime>();
    var ven = (from Ven in DBCon.VenueSchedules
       select new
       {
          Ven.Date,
          Ven.ScheduleID,
        }).ToList();
    listDates.AddRange(ven.Select(item=>Convert.ToDateTime(item.Date)).ToList()); 
