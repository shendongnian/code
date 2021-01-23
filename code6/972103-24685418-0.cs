    public class Registration
    {
        [EmailAddress]
        public string Email { get; set; }
    
        [DataType(DataType.Password)]
        public string Password { get; set; }
    	
    	public virtual ServiceRegistration ServiceRegistration { get; set; }
    }
