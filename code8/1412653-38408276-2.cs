    public class User
        {
            [Key]
            public int UserID { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
    		[ForeignKey("Group")]
            public int GroupID {get;set;}    
            public virtual Group Group{ get; set; }
        }
