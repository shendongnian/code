    List<Author> authors = new List<Author>();
    // assuming you have a SqlCommand "command" executing the query you showed
    using (SqlDataReader reader = command.ExecuteReader())
    {
        while(reader.Read())
        {
            int author_ID = reader.GetInt(0);
            Author author = authors.FirstOrDefault(a => a.Author_ID == author_ID);
            if (author == null)
            {
                author = new Author{
                   Author_ID = author_ID,
                   Author_Name = reader.GetString(1),
                   Year = reader.GetInt(5),
                   Data = new List<AuthorData>()
                };
                authors.Add(author);
            }
   
            author.Data.Add(new AuthorData{
                 CoAuthor_ID = reader.GetInt(2),
                 Paper_ID = reader.GetInt(3),
                 Venue_ID = reader.GetInt(4)
            });
        }
    }
    
