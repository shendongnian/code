    modelBuilder.Entity<Ticket>()
                .HasMany(c => c.Administrators).WithMany(i => i.Tickets)
                .Map(t => t.MapLeftKey("TicketID")
                .MapRightKey("AdministratorID")
                .ToTable("Adminstrators on Tickets"));
