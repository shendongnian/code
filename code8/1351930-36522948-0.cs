            static void Main(string[] args)
            {
                string connectionString = "Server=.;Database=AA;Trusted_Connection=True;";
    
                /*
                CREATE TABLE [dbo].[SystemUser]
                (
                    [ProfilePicture] [varbinary](max) NULL
                )
                */
    
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"
    INSERT [AA].[dbo].[SystemUser] ([ProfilePicture]) VALUES (@ProfilePicture);
    INSERT [AA].[dbo].[SystemUser] ([ProfilePicture]) VALUES (NULL);
    ";
    
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.CommandType = CommandType.Text;
    
                    byte[] bytes = File.ReadAllBytes(@"1.jpg");
                    command.Parameters.AddWithValue("@ProfilePicture", bytes);
    
                    connection.Open();
                    command.ExecuteNonQuery();
                }
    
    
                DataSet ds = new DataSet();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = @"
    SELECT TOP 1000 [ProfilePicture] FROM [AA].[dbo].[SystemUser];
    ";
    
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.CommandType = CommandType.Text;
    
                    connection.Open();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(ds);
                }
    
                var rows = ds.Tables[0].Rows.Cast<DataRow>();
                foreach (DataRow row in rows)
                {
                    byte[] bytes = row.Field<byte[]>(0);
                    if (bytes != null)
                    {
                        string fileName = Guid.NewGuid().ToString("N") + ".jpg";
                        File.WriteAllBytes(fileName, bytes);
                    }
                }
            }
