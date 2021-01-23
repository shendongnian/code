    public class UserFriendship
    {
        public int UserEntityId { get; set; } // the "maker" of the friendship
        public int FriendEntityId { get; set;  }´ // the "target" of the friendship
        public UserEntity User { get; set; } // the "maker" of the friendship
        public UserEntity Friend { get; set; } // the "target" of the friendship
    }
