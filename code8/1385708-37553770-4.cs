        public static void GenericSqlInsert(string connectionString, string table, Object model)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string commandText = "Insert into " + table + "Values(";
                SqlCommand command = new SqlCommand();
                PropertyInfo[] properties = model.GetType().GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    commandText += "@" + property.Name + ",";
                    command.Parameters.AddWithValue("@" + property.Name, property.GetValue(model));
                }
                commandText = commandText.TrimEnd(',');
                commandText += ") ";
                try
                {
                    command.Connection = connection;
                    command.CommandText = commandText;
                    connection.Open();
                    Int32 rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine("RowsAffected: {0}", rowsAffected);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
