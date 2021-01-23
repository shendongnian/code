    	public class Predicate
	    {
		    public string[] HotelName { get; set; } // In javascript can hold: ["HOtel", "==", ""] 
		    public string[] PaymentStatus { get; set; }
	    }
	    public class MyDTO
	    {
		    public string[] IncludeProperties { get; set; }
		    public Predicate predicate { get; set; }
	    }
