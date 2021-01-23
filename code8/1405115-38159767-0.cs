    namespace MVCTutorial.Models
    {
        public class SiteUser
        {
            [Display(Name="First Name")]
            public string FirstName { get; set; }
    
            [Display(Name = "Last Name")]
            public string LastName { get; set; }
    
            [DataType(DataType.EmailAddress)]
            public string EmailAddress { get; set; }
    
            [Display(Name = "Subscribe To Newsletter?")]
            public bool SubscribeToNewsletter { get; set; }
    
            [DataType(DataType.Password)]
            public string Password { get; set; }
    
            [Display(Name="City")]
            public int CityId { get; set; }
        }
    
        public class SiteUserViewModel : SiteUser
        {
            public List<SelectListItem> Cities { get; set; }
        }
    }
