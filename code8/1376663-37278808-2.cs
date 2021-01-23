    Author vascon = new Author { 
                           Author_ID = 677,
                           Author_Name = "Nuno Vascon",
                           Year = 2005,
                           Data = new List<AuthorData>()
    };
    vascon.Data.Add(new AuthorData { 
        CoAuthor_ID = 901706,
        Paper_ID = 812229,
        Venue_ID = 64309
    });
    vascon.Data.Add(new AuthorData { 
        CoAuthor_ID = 901706,
        Paper_ID = 812486,
        Venue_ID = 65182
    });
    vascon.Data.Add(new AuthorData { 
        CoAuthor_ID = 901706,
        Paper_ID = 818273,
        Venue_ID = 185787
    });
    
