    class BookmarkMap: EntityTypeConfiguration<Bookmark>
    {
        public BookmarkMap()
        {
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
        }
    }
