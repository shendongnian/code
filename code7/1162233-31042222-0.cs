    public BookMap()
    {
        Table("book");
        Id(x => x.BookId).Column("bookId");
        Map(x => x.BookName).Column("bookName");
        // authorId column for both
        Map(x => x.AuthorId)
           .Column("authorId")
           .Not.Insert()
           .Not.Update()
           ;
        References(x => x.Author, "authorId");
    }
