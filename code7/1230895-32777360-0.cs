    String query = "INSERT INTO testtabel (knaam, korder) VALUES (@knaam, @korder)"; 
    SqlCommand sqlCommand = new SqlCommand(query, myConnection);
    sqlCommand.Parameters.Add(new SqlParamete("@knaam",knaamTextBox.Text));
    sqlCommand.Parameters.Add(new SqlParamete("@korder",kordernrTextBox.Text));
 
