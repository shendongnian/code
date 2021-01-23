    public Book(ICollection<Author> origAuthors)
    {
        // We only need to allocate the ReadOnlyCollection once.
        this.Authors = new ReadOnlyCollection<Author>( new List<Author>( origAuthors ) );
    }
    public ICollection<Author> Authors { get; private set; }
