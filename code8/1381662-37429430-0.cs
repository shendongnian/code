    public class UserProfileEdit
        {
            public virtual ApplicationUser ApplicationUser { get; set; }
    
            [Required]            
            public string FirstName { get; set; }
    
            public string TwitterHandle{ get; set; }
    
            [Required]
            [Display(Name = "Email")]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }
    
            // etc etc
    
            public UserProfileEdit() {}
    
            public UserProfileEdit(ApplicationUser user) {
                  this.ApplicationUser = user;
                  this.Email = user.Email;
                  // ...
            }
    
    }
     public ActionResult YourProfile()
            {
                string username = User.Identity.Name;           
    
                ApplicationUser user = db.Users.FirstOrDefault(u => u.UserName.Equals(username));
    
                 return View(new UserProfileEdit(user)); 
            }
