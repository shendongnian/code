        public class PostViewModel
        {
            public int Id { get; set; }
            [Required]
            public string PostContent { get; set; }
            [Required]
            public DateTime DatePosted { get; set; }
            [Required]
            public string PostTitle { get; set; }
    
            public ApplicationUserViewModel PostOwner { get; set; }
    
            public List<ApplicationUserViewModel> PostContributors { get; set; }
    
        }
    
