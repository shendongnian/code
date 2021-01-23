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
              
    var attribute = new AuthorAttributes()
    {
    PaperID = new List<int>(),
    CoAuthorID = new List<int>(),
    VenueID = new List<int>()
    };
    attribute.PaperID.Add(myReader_1.GetInt32(2));
    attribute.CoAuthorID.Add(myReader_1.GetInt32(3));
    attribute.VenueID.Add(myReader_1.GetInt32(4));
    attribute.Year = myReader_1.GetInt32(5);
    author.Attributes.Add(attribute);
    
   
    
    eAuthors.Add(author);
    }
    }
