        using (var sqlConnection = new SqlConnection(builder.ConnectionString))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand(query, sqlConnection))
            {
                sqlCommand.StatementCompleted += sqlCommand_StatementCompleted;
                sqlCommand.ExecuteNonQuery();
            }
        }
        Console.ReadLine();
    }
    static void sqlCommand_StatementCompleted(object sender, StatementCompletedEventArgs e)
    {
        Console.WriteLine(e.RecordCount);
    }
