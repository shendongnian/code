    public class ApplicationUser : IdentityUser
	{
		[...]
		public virtual List<ApplicationUserGroup> UserGroups { get; set; }
	}
    public class Group
	{
		[Key] // *** add this attribute
		public int GroupId { get; set; } // *** Change D to d to match ApplicationUserGroup property (this is just to be consistent in your naming conventions!)
		[Required]
		[StringLength(100, MinimumLength = 2)]
		public string Name { get; set; }
		public virtual List<ApplicationUserGroup> UserGroups { get; set; } // *** this has changed also
	}
