      public class User
        {
            public User() { }
            public int UserId { get; set; }
            public string Name { get; set; }
            public virtual Friends friends { get; set; }
        }
        public class Friends
        {
            public Friends()
            {
                Users = new List<User>();
            }
            public int FriendId { get; set; }
            public string Name { get; set; }
            public virtual ICollection<User> Users { get; set; }
        }
