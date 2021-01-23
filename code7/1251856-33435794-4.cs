    using (HatronEntities context = new HatronEntities())
    {
    	DateTime date = DateTime.Today;
    	var AttendData = (from c in context.tbl_CoachMobAttendDetails
    						where c.CoachId == model.Id && 
    						DbFunctions.TruncateTime( c.InDateTime ) == date
    						select c).FirstOrDefault();
    }
