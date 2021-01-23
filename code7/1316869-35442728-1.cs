        public class ApplicationUserViewModel
        {
            public int UserId { get; set; }
            [Required]
            public string UserName { get; set; }
            [Required]
            public string FirstName { get; set; }
            [Required]
            public string LastName { get; set; }
            [Required]
            public string Email { get; set; }
    
            public virtual ICollection<PostViewModel> Posts { get; set; }
    
        }
    
