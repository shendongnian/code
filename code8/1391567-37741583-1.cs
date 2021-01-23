    public class EmailNotification
    {
        public int ID { get; set; }
        //other stuff...
        public virtual ICollection<User> Users { get; set; }
    }
    
    public class User
    {   
        public int ID { get; set; }
        //other stuff...
        public virtual ICollection<EmailNotification> EmailNotifications { get; set; }
    }
