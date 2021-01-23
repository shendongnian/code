    var library = new List<IBook>();
    var book1 = new ProgrammingBook(ProgrammingLanguage.CSharp) {Title = "C# in Depth", Author = "Jon Skeet"};
    var book2 = new CookBook() { Title = "Everyday Superfood", Author= "Jamie Oliver" };
    library.Add(book1);
    library.Add(book2);
    // now you can loop all and you know that all books have these properties
    foreach (IBook book in library)
    {
        Console.WriteLine("Title: {0} Type: {1}", book.Title, book.BookType.ToString());
    }
