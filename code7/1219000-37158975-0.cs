    public class User
    {
        public User() { }
        [Key]
        public string ID { get; set; }
        public string Name { get; set; }
    }
    public class UserSetting
    {
        public UserSetting() { }
        [Key]
        public string ID { get; set; }
        public string Settings { get; set; }
    }
