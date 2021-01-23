    // this might not work right now - you need to adapt this to that
    // you can convert your strings like 'vendredi 13 mars 2015' to a
    // valid "DateTime" object
    DateTime dateTimeFromRow = Convert.ToDateTime(dt.Rows[i][j]);
    // set up your DB connection string    
    string connectionString = "....";
    // define your insert query with PARAMETERS
    string insertQuery = "INSERT INTO [test]([Datedes]) VALUES(@DateDes);";
    // use "using" blocks to properly dispose of connection and command    
    using (SqlConnection conn = new SqlConnection(connectionString))
    using (SqlCommand command = new SqlCommand(insertQuery, conn)
    {
        //  define and set value for parameter
        command.Parameters.Add("@DateDes", SqlDbType.Date);
        command.Parameters["@DateDes"].Value = dateTimeFromRow;
        // open connection, execute INSERT, close connection        
        conn.Open();
        command.ExecuteNonQuery();
        conn.Close();
    }
