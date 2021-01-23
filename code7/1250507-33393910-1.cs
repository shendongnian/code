    public class User
    {
    	public long ID { get; set; }
    	public string Name { get; set; }
    	public string FirstName { get; set; }
    	public string Password { get; set; }
    	public bool IsDeleted { get; set; }
    	public bool IsActive { get; set; }
    	public virtual ICollection<Profile> Profiles { get; set; }
    	public virtual ICollection<UserEvent> Events { get; set; }
    }
