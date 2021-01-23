        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany<EmailNotification>(s => s.EmailNotification)
                .WithMany(c => c.User)
                .Map(cs =>
                        {
                            cs.MapLeftKey("UserId");
                            cs.MapRightKey("EmailNotificationId");
                            cs.ToTable("UserEmailNotifications");
                        });
        }
