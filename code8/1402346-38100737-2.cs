    public class Player
    {
        [Key]
        public int PlayerID { get; set; }
        public int OrganizationID { get; set; }
        public int CurrentTeamID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime JoinDate { get; set; }
        [ForeignKey("PlayerID")]
        public virtual PlayerAccount Account { get; set; }
        //[ForeignKey("PlayerID")]
        //public virtual PlayerCareer Career { get; set; }
        //[ForeignKey("PlayerID")]
        //public virtual PlayerInfo Info { get; set; }
    }
