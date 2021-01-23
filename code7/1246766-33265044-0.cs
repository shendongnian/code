    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Message>()
            .HasOptional(c=>c.Sender).WithMany().HasForeignKey(c=>c.UserId)
            .HasMany(c=>c.Recepients).WithMany(c=>c.IncomingMessages);
    }
