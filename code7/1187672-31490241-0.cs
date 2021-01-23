    public class Risk
    {
    	public int Id { get; set; }
    	public string Title { get; set; }
    	public Resource Owner { get; set; }
    	public RiskStatus Status { get; set; }
    	public int RiskScore { get; set; }
    
    	public override string ToString()
    	{
    		return string.Format("Risk Id: {0}, Risk Title: {1}, Owner Id: {2}, Owner Name: {3}, Risk Status: {4}, Risk score: {5}",
    								this.Id, this.Title, this.Owner.Id, this.Owner.Name, this.Status.ToString(), this.RiskScore);
    	}
    }
