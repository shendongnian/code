    foreach (AbstractItem item in collection)
    {
        // common book and journal code here
        if (item is Book)
        {
            // some code for books
        }
        else if (item is Journal)
        {
            // some code for journals
        }
    }
    
    // another way:
    List<Book> books = collection.OfType<Book>().ToList();
    List<Journal> journals = collection.OfType<Journal>().ToList();
