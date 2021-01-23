    var orderedBooks = books.OrderBy(x => x.Date.Year).ThenBy(x => x.Date.Month).ThenBy(x => x.Date.Day);
    Book last = null;
    foreach (Book book in orderedBooks)
    {
        Console.WriteLine(book.Title);
        Console.WriteLine(book.Tipology);
        if(last != null  && last.Date.Month != book.Date.Month)
            Console.WriteLine(DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(book.Date.Month)); // With culture
        if (last != null && last.Date.Year != book.Date.Year)
            Console.WriteLine(book.Date.Year.ToString()); 
        last = book;
    }
