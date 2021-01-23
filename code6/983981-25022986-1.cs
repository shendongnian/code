    public class TicketConfiguration : EntityTypeConfiguration<Ticket>
    {
        public TicketConfiguration()
        {
            HasRequired(x => x.Owner)
                .WithMany()
                .HasForeignKey(x=>x.OwnerId);
            Property(x => x.OwnerId)
                .HasColumnName("Owner_Id");
            HasOptional(x => x.LockedByUser)
                .WithMany()
                .HasForeignKey(x => x.LockedByUserId);
            Property(x => x.ETag)
                .IsConcurrencyToken(true);
        }
    }
