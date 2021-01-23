    private void searchButton_Click(object sender, EventArgs e)
    {
        libraryList.Items.Clear();
        // ISBN number search
        var isbnNo = ISBNtext.Text;
        if (!string.IsNullOrEmpty(isbnNo)){
          if (library.ContainsKey(isbnNo)){
            var book = library[isbnNo];
            libraryList.Items.Add(String.Format("{0} = {1}", book.ISBNNo, book.Title));
          }
        }
    
        // Title search
        var titleText = TITLEtext.Text;
        if (!string.IsNullOrEmpty(titleText)){
          foreach (KeyValuePair<string, Book> book in library)
          {
              // search based on title like your existing code
          }
        }
    
        ISBNtext.Clear();
        TITLEtext.Clear();
    }
