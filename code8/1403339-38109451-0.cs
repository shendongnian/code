    public class TemplatesMaps
    {
    	[Key]
    	public virtual int Id { get; set; }
    	public virtual Template Template { get; set; }
    	public virtual EmployeeBody Employee { get; set; }
    	public virtual UserBody User { get; set; }
    }
