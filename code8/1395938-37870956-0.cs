	public class User
	{
		// User stuff
		
		// Bridge table
		public virtual ICollection<UserFile> Files { get; set; }
	}
	public class File
	{
		// Other File stuff ....
		
		// Bridge table
		public virtual ICollection<UserFile> Users { get; set; }
	}
    // Bridge table
	public class UserFile
	{
		public User User { get; set; }
		public File File { get; set; }
        public DateTime CreatedDate { get; set; }
        // Other metadata here.
	}
