    TGenreTypes genre;
    if (Enum.TryParse(readerFromFile.ReadString(), out genre))
    {
        myBooks.genre = genre;
    }
    else
    {
        // Handle when parse error if needed
    }
