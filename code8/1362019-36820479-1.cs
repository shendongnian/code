    private static readonly object syncRoot = new object();
    public void addBook(int id, string title, string author)
    {
        lock (syncRoot)
        {
            booksList.Add(new Book(id, title, author));
        }
    }
