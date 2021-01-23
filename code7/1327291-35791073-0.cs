    modelBuilder.Entity<Administrator>()
               .HasKey(e => e.AdministratorID);
    public class Administrator
    {
        [Key]
        public int AdminID { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public int TicketID { get; set; }        
        [StringLength(50)]
        public string AdminRole { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual User User { get; set; }
    }
