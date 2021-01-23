    public override int SaveChanges()
    {
        var deletedArticleHeadings = ChangeTracker.Entries<ArticleHeading>().Where(x => x.State == EntityState.Deleted).ToList();
        foreach (var headingEntry in deletedArticleHeadings)
        {
            var heading = headingEntry.Entity;
            // Delete things.
        }
        return base.SaveChanges();
    }
