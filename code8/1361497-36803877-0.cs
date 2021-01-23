    using System.ComponentModel.DataAnnotations;
    namespace YourCompany.YourProject.Models
    {
        public class ApplicationUser : IdentityUser
        {
            [Key]
            public string UserId { get; set; }
        }
        public class ApplicationRole : IdentityRole
        {
            [Key]
            public string Id { get; set; }
        }
        public class ApplicationUserRole : IdentityUserRole
        {
            [Key]
            public string UserId { get; set; }
    
            [Key]
            public string RoleId { get; set; }
        }
        public class ApplicationUserClaim : IdentityUserClaim { }
        public class ApplicationUserLogin : IdentityUserLogin { }
    }
