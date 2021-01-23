    listDates = new List<DateTime>();
    
    var ven = (from Ven in DBCon.VenueSchedules
               select new
    
               {
                   Ven.Date,
                   Ven.ScheduleID,
    
               }).ToList();
                listDates.AddRange(Convert.ToDateTime(ven.Date)); 
