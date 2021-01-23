    try {
    MySqlConnection connection = new MySqlConnection("SERVER=localhost;DATABASE=testdb;UID=root;PASSWORD=;");
    MySqlCommand command = new MySqlCommand();    
    
    connection.Open();
    string selectQuery = "SELECT NAME FROM testtable WHERE Phone LIKE '12%' ORDER BY ID LIMIT 1";
    command.Connection = connection;
    command.CommandText = selectQuery;
    string PersonName = (string)command.ExecuteScalar();
    }
    catch (Exception ex) {
    MessageBox.Show(ex.Message);
    }
    finally {
        connection.Close();
    }
