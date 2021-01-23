    public class Contact {
            public string name { get; set; }
            public string surname { get; set; }
            [EmailAddress(ErrorMessage = "Invalid Email Address")]
            public string email { get; set; }
            public string description{ get; set; }    
        }
     
