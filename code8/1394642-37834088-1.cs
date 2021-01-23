    var books = db.Books;
    if (!string.IsNullOrEmpty(cmbAuth.Text))
        books = books.Where(b => b.Author == cmbAuth.Text);
    if (!string.IsNullOrEmpty(cmbClassi.Text))
        books = books.Where(b => b.Classification == cmbClassi.Text);
    // etc.
