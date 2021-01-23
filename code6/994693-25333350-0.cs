    public class Message {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual User User { get; set; }
        public virtual Group Group { get; set; }
    }
    public class User {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
    public class Group {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
