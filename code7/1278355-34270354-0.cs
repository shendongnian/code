    using (SqlConnection cn = new SqlConnection("Connection String Here"))
            {
                cn.Open();
                var cmd = new SqlCommand
                    (
                        "CREATE TABLE [dbo].[MyTable] " +
                        "( " +
                        "[Id] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY, " +
                        "[MyColumn] VARCHAR(50) NULL " +
                        ")",
                        cn
                    );
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
