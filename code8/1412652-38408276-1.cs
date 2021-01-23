    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int GroupID {get;set;}    
        [ForeignKey("GroupID ")]
        public virtual Group Group{ get; set; }
    }
