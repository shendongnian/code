    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        // Blog
        var blog = modelBuilder.Entity<Blog>();
        blog.ToTable("Blogs");
        blog.HasKey(b => b.BlogGuid);
        blog.HasMany(b => b.Comments).WithRequired().HasForeignKey(c => c.BlogGuid);
        // Blog Summary
        modelBuilder.Ignore<BlogSummary>();
        // Blog Comment
        var blogComment = modelBuilder.Entity<BlogComment>();
        blogComment.ToTable("BlogComments");
        blogComment.HasKey(c => c.BlogCommentGuid);
    }
