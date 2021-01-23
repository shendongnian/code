    public class User
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public virtual ICollection<Alarm> Alarms { get; set; }
        public User()
        {
            Alarms = new HashSet<Alarm>();
        }
    }
