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
    
            public void Init(ApplicationUser user) {
                  this.ApplicationUser = user;
                  this.Email = user.Email;
                  // do what you want to do
            }
    
    }
    
     public ActionResult YourProfile()
            {
                string username = User.Identity.Name;           
    
                ApplicationUser user = db.Users.FirstOrDefault(u => u.UserName.Equals(username));
                UserProfileEdit vm = new UserProfileEdit();
                vm.Init(user);
    
                 return View(vm); 
            }
