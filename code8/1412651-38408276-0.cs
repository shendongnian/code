    public class Group
    {		
        [Key]
        public int GroupID { get; set; }
        public string GroupName { get; set; }
		public virtual ICollection<User> Users { get; set;}
    }
