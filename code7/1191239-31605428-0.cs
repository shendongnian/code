LookUpViewModel.cs
    public class LookUpViewModel {
        [Display(Name = "Location")]
        [Required(ErrorMessage = "Please select a location")]
        public int SelectedLocation { get; set; }
        
        public SelectList LocationList { get; set; }
    }
tblCurrentLocations.cs
    public class tblCurrentLocations {
        public int LocationId { get; set; }
        public string Location {get;set;}
    }
tblUser.cs
    public class tblUser {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name required")]
        public string FirstName {get; set;}
    }
