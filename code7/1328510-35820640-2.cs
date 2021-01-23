	public class TestClassForMongo
	{
	    public ObjectId Id { get; set; }
		
		[BsonDateTimeOptions]
	    public DateTime CreatedDateUtc { get; set; }
	    
		public string Message { get; set; }
	}
