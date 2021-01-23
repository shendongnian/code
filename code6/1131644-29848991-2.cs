    public class ApplicationUser : IdentityUser
    {
    
        [StringLength(250, ErrorMessage = "About is limited to 250 characters in length.")]
        public string About { get; set; }
        
        [StringLength(250, ErrorMessage = "Name is limited to 250 characters in length.", MinimumLength=3)]
        public string Name { get; set; }
    
        public DateTime DateRegistered { get; set; }
        public string ImageUrl { get; set; }
    
        public virtual ICollection<Notification> Notifications { get; set; }
    
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    public class Notification
    {
        public int ID { get; set; }
        public int? CommentId { get; set; }
        public string ApplicationUserId { get; set; }
        public DateTime DateTime { get; set; }
        public bool Viewed { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Comment Comment { get; set; }
 
    }
}
