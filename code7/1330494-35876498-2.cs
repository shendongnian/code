    void Test() {
        List<Author> mutableAuthors = new List<Author>();
        mutableAuthors.AddRange( ... add 5 authors ... );
    
        Book testBook = new Book( mutableAuthors );
        mutableAuthors.Clear();
    
        // Prints 5.
        Console.Writeline( testBook.Authors.Count );
    
        Author someAuthor = testBook.Authors[0];
        someAuthor.ChangeName("A new name");
    
        // Prints "A new name".
        Console.WriteLine( testBook.Authors[0] );
    }
