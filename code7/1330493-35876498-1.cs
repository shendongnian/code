    void Test() {
        List<Author> mutableAuthors = new List<Author>();
        mutableAuthors.AddRange( ... add 5 authors ... );
    
        Book testBook = new Book( mutableAuthors );
        mutableAuthors.Clear();
    
        // Prints 5.
        Console.Writeline( testBook.Authors.Count );
    
        // Throws an exception from ReadOnlyCollection.
        testBook.Authors.Clear();
    }
