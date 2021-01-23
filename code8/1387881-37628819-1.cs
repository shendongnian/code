    class ApplicationUserTeam
    {
        [Key, Column(Order = 1)]
        public int ApplicationUserID { get; set; }
        [Key, Column(Order = 2)]
        public int TeamID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Team Team { get; set; }
    }
    class ApplicationUser
    {
        public ApplicationUser()
        {
            ApplicationUserTeams = new HashSet<ApplicationUserTeam>();
        }
        public int ID { get; set; }
        public ICollection<ApplicationUserTeam> ApplicationUserTeams { get; set; }
    }
    class Team
    {
        public Team()
        {
            ApplicationUserTeams = new HashSet<ApplicationUserTeam>();
        }
        public int ID { get; set; }
        public ICollection<ApplicationUserTeam> ApplicationUserTeams { get; set; }
    }
