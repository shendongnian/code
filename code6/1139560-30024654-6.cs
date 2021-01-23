	public class ErrorMessage
	{
	    public string EventId { get; set; }
		public string TransactionId { get; set; }
	    public DateTime Timestamp { get; set; } 
	    public string Component { get; set; }
	    public string UserId { get; set; }
	    public string Message { get; set; }
	    public Exception Exception { get; set; }
	}
