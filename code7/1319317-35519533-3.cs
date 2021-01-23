    public class ToDo
    {
        [NotMapped]
        private ApplicationUserManager _userManager;
        [NotMapped]
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool Done { get; set; }
        public ApplicationUser User { get; set; }
        public ToDo ParentTask { get; set; }
        public ToDo(ApplicationDbContext context)
        {
            // code to search user in to given context and set it to `User` Property
        }
        public ToDo(string userId)
        {
            // code to search user using UserManager by Id, can change it to include email, username or any other property and set it to `User` Property
        }
    }
