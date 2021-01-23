    var xDocument = XDocument.Parse(@"<bookstore>
                                    <book>
                                    <bookID>100</bookID>
                                    <name> The cat in the hat </name>
                                    </book>
                                    <book bookID=""90"">
                                    <name> another book </name>
                                    </book>
                                    <book>
                                    <bookID>103</bookID>
                                    <name> a new book </name>
                                    </book>
                                    </bookstore>");
    
    foreach (var xBook in xDocument.Descendants("book"))
    {
        var bookIdNode = xBook.Elements("bookID").FirstOrDefault();
        int bookId = 0;
    
        ///there is a book id as an element
        if (bookIdNode != null)
        {
            //invalid book id.. should be an int
            if (!int.TryParse(bookIdNode.Value, out bookId))
                continue;
        }
        else
        {
            var bookIdAttr = xBook.Attributes("bookID").FirstOrDefault();
            if (bookIdAttr == null || !int.TryParse(bookIdAttr.Value, out bookId))
                continue;
        }
    
        if (bookId == 0)
            continue;
    
        //else we got our book id
    
    }
