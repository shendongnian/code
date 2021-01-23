	public virtual ICollection<Event2Location> Event2Locations { get; set; }
	[NotMapped]
	public virtual ICollection<Event2Country> Event2Countries => Event2Locations?.OfType<Event2Country>().ToList();
	// I should probably add some caching here if accessed more often
	[NotMapped]
	public virtual ICollection<Event2City> Event2Cities => Event2Locations?.OfType<Event2City>().ToList();
