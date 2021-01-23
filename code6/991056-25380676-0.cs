    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public bool IsPayer { get; set; }
        public bool IsReceiver { get; set; }
        public ICollection<User> Receivers { get; set; }
    }
