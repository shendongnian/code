    public partial class UserProfile
        {
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string PostContent { get; set; }
            public IEnumerable<workingOnAddPost.Entity.UserProfile> UserProfilesCollection { get; set; }
