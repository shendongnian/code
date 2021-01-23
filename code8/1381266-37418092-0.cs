    This is what you want
       
    [Table("REQUEST", Schema = "YourSchema")]
    public class REQUEST
    {
    
    	public REQUEST()
    	{
    		Responses = new HashSet<RESPONSE>();
    		Administrators = new HashSet<ADMINISTRATOR>();
    	}
    
    	[Column("REQUESTID")]
    	public int RequestId { get; set; }
    
    	public virtual ICollection<RESPONSE> Responses { get; set; }
    	public virtual ICollection<ADMINISTRATOR> Administrators { get; set; }
    }
    
    [Table("RESPONSE", Schema = "YourSchema")]
    public class RESPONSE
    {
    	[Column("RESPONSEID")]
    	public int ResponseId { get; set; }
    
    	[Column("REQUESTID")]
    	public int RequestId { get; set; }
    
    	[Column("ADMINISTRATORID")]
    	public int AdministratorId { get; set; }
    
    	[ForeignKey("RequestId")]
    	public virtual REQUEST Request { get; set; }
    
    	[ForeignKey("AdministratorId")]
    	public virtual ADMINISTRATOR Administrator { get; set; }
    }
    
    [Table("ADMINISTRATOR", Schema = "YourSchema")]
    public class ADMINISTRATOR
    {
    	public ADMINISTRATOR()
    	{
    		Requests = new HashSet<REQUEST>();
    		Responses = new HashSet<RESPONSE>();
    	}
    	[Column("ADMINISTRATORID")]
    	public int AdministratorId { get; set; }
    
    	public virtual ICollection<REQUEST> Requests { get; set; }
    	public virtual ICollection<RESPONSE> Responses { get; set; }
    }
		public DbSet<REQUEST> Requests { get; set; }
		public DbSet<RESPONSE> Responses { get; set; }
		public DbSet<ADMINISTRATOR> Administrators { get; set; }
