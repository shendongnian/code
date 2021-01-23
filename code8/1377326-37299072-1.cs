    string con = //your connection string here
    string yourTextValue = Passnummer.Text; //This will extract the text from your textbox and store it in a variable
    using (string con = new SqlConnection()) {
    con.Open();
    var command =
        new SqlCommand("INSERT INTO yourTable(columnname) VALUES (@textValue);", con);
    command.Parameters.AddWithValue("@textValue", yourTextValue);
    command.ExecuteNonQuery();
    con.Close();
    }
