    public class LoanInfo
    {    
    	 public string EmpID { get; set; }
    	 public string Amount { get; set; }
    
    	public LoanInfo(string empID, String amount)
    	{
    		this.EmpID = EmpID;
    		this.Amount = amount;
    	}
    }
