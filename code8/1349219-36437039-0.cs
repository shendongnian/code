    modelBuilder.Entity<Ticket>().
                .HasRequired(t => t.IssuedUser)
                .WithMany(u => u.TicketsIssuedTo)
                .HasForeignKey(t => t.IssueID)
                .WillCascadeOnDelete(false);
