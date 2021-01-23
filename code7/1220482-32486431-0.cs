    public class UserGroupCode
    {
        public int UserGroupCodeId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public string Value { get; set; }
    }
