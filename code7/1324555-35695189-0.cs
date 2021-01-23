    public class Depot
    {      
        public int DepotID { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
    public class User
    {
    
        public int UserID { get; set; }
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }
        [StringLength(50, MinimumLength = 1, ErrorMessage = "First name cannot be longer than 50 characters.")]
    
        [Column("FirstName")]
        public string FirstMidName { get; set; }
    
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }
    
        public string FullName
        {
            get { return LastName + ", " + FirstMidName; }
        }
        public int AdministratorID { get; set; }
        public virtual Administrator Administrator { get; set; }
    
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }
    
        public virtual int DepotID { get; set; }
    	
    	[ForeignKey("DepotID")]
        public virtual Depot Depot { get; set; }
    
        public int TicketID { get; set; }
        public virtual ICollection<Ticket> Users { get; set; }
    
    }
