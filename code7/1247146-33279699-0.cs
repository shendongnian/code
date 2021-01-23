            var sqlConnection1 = new SqlConnection(@"give your connection string here");
            SqlCommand  sqlCommand2 = new SqlCommand();
            sqlCommand2.CommandText = @"update query";
            sqlCommand2.Connection = sqlConnection1;
            sqlConnection1.Open();
            sqlCommand2.ExecuteNonQuery();
            sqlConnection1.Close();
        
