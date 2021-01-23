	IEnumerable<SomeType> query = 
			 from RESTAURANT in db.RESTAURANTs
			 where RESTAURANT.REST_ID == RestID
			 select new SomeType { Name = RESTAURANT.name } ;
			 
	public class SomeType
	{
		public string Name { get; set; }
	}
	
