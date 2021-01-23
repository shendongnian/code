      String bGenres = String.Join(Environment.NewLine, collection
        .Cast<Book>()
        .Select(book => book.BGenre.ToString()));
    
      Console.Write(bGenres); 
