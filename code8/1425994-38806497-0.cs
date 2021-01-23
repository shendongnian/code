    public class ApplicationUser : IdentityUser
    {
        // ...
        public virtual ICollection<FriendRequest> FriendRequests {get; set;}
        public virtual ICollection<FriendRequest> FriendRequested {get; set;}
    }
    
    public class FriendRequest
    {
        public string UserRequestingID { get; set; }
        public string UserBeingRequestedID { get; set; }
        public bool IsIgnored { get; set; }
        public virtual ApplicationUser UserRequesting { get; set; }
        public virtual ApplicationUser UserBeingRequested { get; set; }
    }
