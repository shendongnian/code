    string myConnection = "datasource=localhost;port=3306;username=root;password=";
    MySqlConnection myConn = new MySqlConnection(myConnection);
    MySqlCommand command = myConn.CreateCommand();
    command.CommandText = "Select * FROM database_name.table1";
    MySqlDataReader myReader;
        try
        {
            myConn.Open();
            myReader = command.ExecuteReader();
            while (myReader.Read())
            {
                if(label1.Text.Length > 0)
                     label1.Text += Environment.NewLine;
                for(int i=0; i<myReader.FieldCount; i++)
                    label1.Text += myReader[i].ToString() + "    ";
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        myConn.Close();
