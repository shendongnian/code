    public abstract class Book
    {
    	public int BookId { get; set; }
    	// ...
    	public ICollection<Loan> Loans { get; set; }
    }
