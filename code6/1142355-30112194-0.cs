		public void Display(int id)
		{
			Display(ven => ven.VenueID == id);
		}
		public void Display(string name)
		{
			Display(ven => ven.Shortname == name);
		}
		public void Display(Expression<Func<Venue, bool>> whereClause)
		{
			Venue venue = db.Venues.Where(whereClause).FirstOrDefault();
               /// etc
