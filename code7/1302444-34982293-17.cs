    public void AddBook(string name, string author, int id)
    {
        Book book = new Book{
            Name = name,
            Author = author,
            Id = id
        };
        library.Add(book);
    }
