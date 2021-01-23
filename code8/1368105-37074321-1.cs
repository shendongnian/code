	public class Event2Country : Event2Location
	{
		[NotMapped]
		public Country Country
		{
			get { return base.Location as Country; }
			set { base.Location = value; }
		}
		[NotMapped]
		public int CountryId
		{
			get { return base.LocationId; }
			set { base.LocationId = value; }
		}
	}
