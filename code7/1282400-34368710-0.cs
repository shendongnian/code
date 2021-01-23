    foreach (KeyValuePair<string, Book> book in library)
        {
            if (!string.IsNullOrEmpty(ISBNtext.Text) && book.Key.Contains(ISBNtext.Text) || !string.IsNullOrEmpty(TITLEtext.Text) && book.Value.Title.Contains(TITLEtext.Text))
            {
                libraryList.Items.Add(String.Format("{0} = {1}", book.Key, book.Value.Title));
            }
        }
