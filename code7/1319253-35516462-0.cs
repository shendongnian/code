    private MySqlConnection db_connection()
    {
        try
        {
            conn = "Server=localhost;Database=student;Uid=root;Pwd=admin;";
            MySqlConnection cnn = new MySqlConnection(conn);
            cnn.Open();
            return cnn;
        }
        catch (MySql.Data.MySqlClient.MySqlException ex)
        {
            switch (ex.Number)
            {
                case 0: MessageBox.Show("Cannot connect to server!"); break;
            }
            retur null;
        }
    }
