    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Post>()
            .Collection(p => p.Comments).InverseReference(c => c.Post)
            .ForeignKey(c => c.PostId);
    }
