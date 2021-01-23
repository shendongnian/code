        using(SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            string sql =  "insert into dictionary(word, definition) values(@word, @definition)";
                SqlCommand cmd = new SqlCommand(sql,connection);
                cmd.Parameters.Add("@word", SqlDbType.Varchar, 50).value = textBoxWordtoAdd.Text;
                cmd.Parameters.Add("@definition", SqlDbType.Varchar, 50).value = textBoxDefinition.Text;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
        }
