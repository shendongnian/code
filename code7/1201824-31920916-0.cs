    public class ApplicationUserViewModel : ApplicationUser
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Skype { get; set; }
            public string About { get; set; }
            public Photo Avatar { get; set; }
        }
