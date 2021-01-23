    class Note
    {
    	public int Id { get; set; }
    	public string Content { get; set; }
    }
    class BusinessPartner
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public virtual ICollection<Note> Notes { get; set; }
    }
    class Opportunity
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public virtual ICollection<Note> Notes { get; set; }
    }
