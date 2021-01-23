    public class ShowcaseModel
    {
    	public string AuditoriumId { get; set; }
    	public string MovieId { get; set; }
    	public Startdate StartDate { get; set; }
    	public DateTime createdAt { get; set; }
    	public string objectId { get; set; }
    	public DateTime updatedAt { get; set; }
    }
    
    public class Startdate
    {
    	public string __type { get; set; }
    	public DateTime iso { get; set; }
    }
