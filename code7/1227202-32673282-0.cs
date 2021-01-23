    // Get an array of search terms... search for as many as you like
    string[] searchTerm = txtName.Text.ToLower().Split(' ');
    List<Person> searchResult = new List<Person>();
    foreach (string term in searchTerm)
    {
        searchResult.AddRange(People.FindAll(p => p.Name.ToLower().Contains(term)
            || p.Postort.ToLower().Contains(term)));
    }
