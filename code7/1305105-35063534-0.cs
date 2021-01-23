	[ResponseType(typeof(Detail))]
	public IHttpActionResult GetDetail(string StartDate, string EndDate)
	{
		DateTime StartDateTime = DateTime.ParseExact(StartDate, "yyyyMMddhhmm", null);
		DateTime EndDateTime = DateTime.ParseExact(EndDate, "yyyyMMddhhmm", null);
		var detail = from a in db.Details where (DateTime.ParseExact(a.callDate, "yyyyMMddhhmm", null) >= StartDateTime && 
						DateTime.ParseExact(a.callDate, "yyyyMMddhhmm", null) <= EndDateTime) select a;
	}
