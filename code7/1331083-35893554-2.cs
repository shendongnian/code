    public Book SearchSpecificBook(BookSearchType selectedSearch, string input)
    {
        switch (selectedSearch)
        {
            case BookSearchType.Title:
                return BookContainer.FirstOrDefault(x => x.Title == input).ToList();
            case BookSearchType.Author:
                return BookContainer.FirstOrDefault(x => x.Author == input).ToList();
            // ...
            default:
                throw new ArgumentOutOfRangeException(nameof(selectedSearch));
        }
    }
