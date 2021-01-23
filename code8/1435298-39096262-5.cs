	IPagedList<Computer> computers = db.Computers
		.Where(c => c.CurrentSite.ID == SiteID)
		.OrderBy(c => c.CurrentSite.ID) // Or some other property.
		.ToPagedList(1, 25);
		
