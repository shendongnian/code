    public class BaseModel{
           [Required(ErrorMessage = "Enter Firstname")]
            public string Firstname { get; set; }
    
            [Required(ErrorMessage = "Enter LastName")]
            public string LastName { get; set; }
    
            [Required(ErrorMessage = "Enter UserName")]
            public string UserName { get; set; }
    
    
    }
    
       public class UserModel : BaseModel
      {
           
            [Required(ErrorMessage = "Enter Password")]
            public string Password { get; set; }
       
            [Required(ErrorMessage = "Enter Contact")]
            public string Contact { get; set; }
    
            [Required(ErrorMessage = "Enter Address")]
            public string Address { get; set; }
      }
    
    Hope it will help you to reduce redundancy and work with different view also , i think that is he best way to tackle this kind of problem Thanks
