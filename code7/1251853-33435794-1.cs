    using (HatronEntities context = new HatronEntities())
    {
    	DateTime date = DateTime.Today;
    	DateTime until = date.AddDays(1);
    	var AttendData = (from c in context.tbl_CoachMobAttendDetails
    						where c.CoachId == model.Id && 
    						c.InDateTime.Value >= date &&
    						c.InDateTime.Value < until
    						select c).FirstOrDefault();
    }
