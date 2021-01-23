	public class RegistrationViewModel {
		[Display(Name = "Event")]
		public string EventName { get; set; }
	
		[Required]
		[Display(Name = "First name")]
		public string FirstName { get; set; }
		
		[Required]
		[Display(Name = "Last name")]
		public string LastName { get; set; }
	}
