        using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(Connectionstring))
        {
            sqlConnection.Open();
            string sqlQuery = "DELETE FROM [dbo].[Customer] WHERE CustomerId=@CustomerId";
            sqlConnection.Execute(sqlQuery, new {customerId});
            sqlConnection.Close();
        }
