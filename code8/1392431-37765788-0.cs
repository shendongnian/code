        while (myReader_1.Read())
        {
           int authorID = myReader_1.GetInt32(0);
           Author author = eAthors.FirstOrDefault(_a => _a._AuthorID == _authorID);
           if (author == null)
           {
              author = new Author
                                    {
                                        AuthorID = authorID,
                                        AuthorName = myReader_1.GetString(1),
                                        Attributes = new List<AuthorAttributes>()
                                    };
            }  
    
    author.Attributes.Add(new AuthorAttributes()
    {
    PaperID = new List<int>(),
    CoAuthorID = new List<int>(),
    VenueID = new List<int>()
    });
    
    author.PaperID.Add(myReader_1.GetInt32(2));
    author.CoAuthorID.Add(myReader_1.GetInt32(3));
    author.VenueID.Add(myReader_1.GetInt32(4));
    author.Year = myReader_1.GetInt32(5);
    
    eAuthors.Add(author);
    }
