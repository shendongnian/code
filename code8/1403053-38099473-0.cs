	public class Contract
	{
	    public Contract()
	    {
	        Contracts = new List<Contract>();
	    }
	    public int Id { get; set; }
	    public virtual IList<Contract> Contracts { get; set; }
	}
