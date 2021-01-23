    public class UserEntity
    {
        
        //...
        //friend request that I made
        public virtual ICollection<UserFriendship> FriendRequestsMade { get; set; }
        //friend request that I accepted
        public virtual ICollection<UserFriendship> FriendRequestsAccepted { get; set; }
    }
