    public void GetBookInfo (string bookID)
    {
        // Call overload passing bookID and empty string as book name
        return GetBookInfo(bookId, string.Empty);
    }
    public void GetBookInfo (string bookID, string bookName)
    {
        // Call overload passing bookID, bookName and empty string as author
        return GetBookInfo(bookId, bookName, string.Empty);
    }
    public void GetBookInfo (string bookID, string bookName, string author)
    {
        // All 3 parameters are populated here, get the book info...
    }
