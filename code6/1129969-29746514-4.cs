    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public User ContactUser { get; set; }
    }
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public Contact Contact { get; set; }
    }
