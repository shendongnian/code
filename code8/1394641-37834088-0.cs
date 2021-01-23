    var query = "SELECT * FROM Books WHERE 1 = 1";
    var parameters = new List<SqlParameter>();
    if (!string.IsNullOrEmpty(cmbAuth.Text))
    {
        query = query + " AND Author = @Author";
        parameters.Add(new SqlParameter("@Author", cmbAuth.Text));
    }
    // repeat for each input
    // then build and execute the connection/command objects from the query and parameters
