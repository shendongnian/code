        public class User
        {
            public int UserId{ get; set; } /*your properties*/  
        
            public virtual ICollection<EmailNotification> Courses { get; set; }
        }
        public class EmailNotification
        {
            public int EmailNotificationId{ get; set; } /*your properties*/  
        
            public virtual ICollection<User> Courses { get; set; }
        }
