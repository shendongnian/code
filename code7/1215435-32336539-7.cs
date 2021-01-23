    public CommentsMap()
    {
        Id(x => x.Id);
        ...
        References(x => x.Books)
            .Column("Book_ID")
            .Not.Nullable();
    }
