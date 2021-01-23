    public class JobSightDBContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
            modelbuilder.Entity(typeof (ChangeOrder))
                .HasOne(typeof (User), "ApprovedBy")
                .WithMany()
                .HasForeignKey("ApprovedByID")
                .OnDelete(DeleteBehavior.Restrict); // no ON DELETE
            modelbuilder.Entity(typeof (ChangeOrder))
                .HasOne(typeof (User), "AssignedTo")
                .WithMany()
                .HasForeignKey("AssignedToID")
                .OnDelete(DeleteBehavior.Restrict); // no ON DELETE
            modelbuilder.Entity(typeof (ChangeOrder))
                .HasOne(typeof (User), "CreatedBy")
                .WithMany()
                .HasForeignKey("CreatedByID")
                .OnDelete(DeleteBehavior.Cascade); // set ON DELETE CASCADE
        }
    
        DbSet<ChangeApprovalStatus> ChangeApprovalStatus { get; set; }
        DbSet<ChangeImpact> ChangeImapct { get; set; }
        DbSet<ChangeOrder> ChangeOrders { get; set; }
        DbSet<ChangePriority> ChangePriorities { get; set; }
        DbSet<ChangeStatus> ChangeStatus { get; set; }
        DbSet<ChangeType> ChangeTypes { get; set; }
        DbSet<User> Users { get; set; }
    }
