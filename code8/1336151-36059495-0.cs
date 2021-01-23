    protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
    
                modelBuilder.Entity<Post>()
                    .HasMany<Image>(s => s.Gallery)
                    .WithMany(c => c.Posts)
                    .Map(cs =>
                    {
                        cs.MapLeftKey("PostID");
                        cs.MapRightKey("ImageID");
                        cs.ToTable("PostImages");
                    });
            }
