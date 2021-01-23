	using (AltairEntities context = new AltairEntities())
	{
		dtlCoach coach = context.dtlCoaches.FirstOrDefault(x => x.CoachID == coachId);
		coach.Name = "Bob";
		coach.Description = "sample";
		//coach.dtlCoachAddresses.Add(PrepareAddress(coach.dtlCoachAddresses.First().CoachAddressID));
		//context.Database.Connection.Open();
		//context.Entry(coach).State = EntityState.Modified;
		
		var address = context.dtlCoachAddresses.FirstOrDefault(a => a.CoachAddressID == coachId);       
		if(address != null)
	   {
		 address.AddressLine1 = "Line 1";
		 address.AddressLine2 = "Line 2";		                            
	   }	 
		context.SaveChanges();
	}
	/*This function is not required
    public static dtlCoachAddress PrepareAddress(int existingId)
	{
	using (AltairEntities context = new AltairEntities())
	{
	var address = context.dtlCoachAddresses.FirstOrDefault(a => a.CoachAddressID == coachId);       
	 if(address != null)
	 {
		 address.AddressLine1 = "Line 1";
		 address.AddressLine2 = "Line 2";
		 context.SaveChanges();//update an existing address.                             
	 }
	}
	catch (Exception ex)
	{
	throw ex;
	}
	}*/
