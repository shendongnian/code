    public class STask
    {
	    public string ProviderId {get;set;}
    	public string Id{get;set;}
    	public string UserEmail{get;set;}
    	public string Name{get;set;}
	    public string Status{get;set;}
    	public string CompleteBy{get;set;}
	    public double CompleteAtLat{get;set;}
    	public double CompleteAtLon{get;set;}
	    public int PerformWithin{get;set;}
    	public string AdditionalInfo{get;set;}
	    public bool UserCanReject{get;set;}
    	public string StartTime{get;set;}
	    public string CompleteTime{get;set;}
     	public double ActualCompleteAtLat{get;set;}
	    public double ActualCompleteAtLon{get;set;}
    	public string UserNotes{get;set;}
    	public STaskActivity[] STaskActivities{get;set;}
    	public STaskHistory[] STaskHistories{get;set;}
    }
