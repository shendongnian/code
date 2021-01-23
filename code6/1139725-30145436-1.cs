    public class ApplicationUser : IdentityUser
    {
        [ForeignKey("UserInfo")]
        public int UserInfo_Id { get; set; }
        public virtual UserInfo UserInfo { get; set; }
